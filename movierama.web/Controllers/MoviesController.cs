using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using movierama.models;
using movierama.services;
using movierama.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.ResultOperators.Internal;

namespace movierama.web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IVoteService _voteService;

        public MoviesController() : this(new MovieService(), new VoteService())
        {
        }

        private MoviesController(IMovieService movieService, IVoteService voteService)
        {
            _movieService = movieService;
            _voteService = voteService;
        }

        // GET
        public IActionResult Index(int postedBy, string orderBy)
        {
            var movies = _movieService.GetMoviesWithUserVote(3);
            var moviesQ = movies
                .Where(movie => postedBy > 0
                    ? movie.PostedByUserId == postedBy
                    : movie.PostedByUserId > 0);

            switch (orderBy)
            {
                case "likes":
                    moviesQ = moviesQ.OrderBy(movie => movie.Likes);
                    break;
                case "hates":
                    moviesQ = moviesQ.OrderBy(movie => movie.Hates);
                    break;
                case "date":
                    moviesQ = moviesQ.OrderBy(movie => movie.PublishedDate);
                    break;
            }

            var moviesView = new MoviesView
            {
                Movies =
                    moviesQ
                        .ToList()
                        .ToMoviesView()
            };
            return View(moviesView);
        }

        [Route("Movies/Like")]
        [HttpPost]
        public IActionResult Like(int movieId)
        {
            _voteService.LikeMovie(movieId, 3);
          return RedirectToAction(nameof(Index));
        }
        
        [Route("Movies/Hate")]
        [HttpPost]
        public IActionResult Hate(int movieId)
        {
            _voteService.HateMovie(movieId, 3);
            return RedirectToAction(nameof(Index));
        }
        
        [Route("Movies/Add")]
        [HttpPost]
        public IActionResult Add(AddMovieView addMovieView)
        {
            
            return RedirectToAction(nameof(Index));
        }
        
    }

    public static class MoviesExtensions
    {
        public static IEnumerable<MovieView> ToMoviesView(this List<Movie> movies)
        {
            var moviesView = new List<MovieView>();
            foreach (var movie in movies)
            {
                var movieView = new MovieView
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    PostedBy = new UserView
                    {
                        Id = movie.PostedBy.Id,
                        Name = movie.PostedBy.Name
                    },
                    Likes = movie.Likes,
                    Hates = movie.Hates,
                    HasVotes = movie.HasVotes,

                    TimePastSincePosted = ConvertToTimePastSincePosted(movie.PublishedDate),

                    Like = movie.HaveVoted && movie.MyVote.Like,
                    Hate = movie.HaveVoted && !movie.MyVote.Like,
                    HaveVoted = movie.HaveVoted,
                    CanVote = movie.PostedBy.Id != 3,
                    PostedByYou = movie.PostedBy.Id == 3
                };

                moviesView.Add(movieView);
            }

            return moviesView;
        }

        private static string ConvertToTimePastSincePosted(DateTime moviePublishedDate)
        {
            var age = DateTime.Now.Subtract(moviePublishedDate);

            if (age.Days > 0)
            {
                return string.Format("{0} {1}", age.Days, age.Days > 1 ? "days" : "day");
            }

            if (age.Hours > 0)
            {
                return string.Format("{0} {1}", age.Hours, age.Hours > 1 ? "hours" : "hour");
            }

            return string.Format("{0} {1}", age.Minutes, age.Minutes > 1 ? "minutes" : "less than a minute");
        }
    }
}