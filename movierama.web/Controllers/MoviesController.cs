using System;
using System.Collections.Generic;
using System.Linq;
using movierama.models;
using movierama.models.Movies;
using movierama.services;
using movierama.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

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

        public int CurrentUserId => HttpContext.User.Identity.IsAuthenticated
            ? int.Parse(HttpContext.User.Identity.Name.Split('-')[0])
            : 0;
        
        // GET
        public IActionResult Index(int postedBy, string orderBy)
        {
            var movies = _movieService.GetMoviesWithUserVote(CurrentUserId);
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
                        .ToMoviesView(CurrentUserId),
                CanAddMovie = HttpContext.User.Identity.IsAuthenticated
            };
            return View(moviesView);
        }

        [Route("movies/{movieId}/like")]
        public IActionResult Like(int movieId)
        {
            _voteService.LikeMovie(movieId, CurrentUserId);
          return RedirectToAction(nameof(Index));
        }
        
        [Route("movies/{movieId}/hate")]
        public IActionResult Hate(int movieId)
        {
            _voteService.HateMovie(movieId, CurrentUserId);
            return RedirectToAction(nameof(Index));
        }
        
        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddMovieView addMovieView)
        {
            if (ModelState.IsValid)
            {
                _movieService.Add(addMovieView.ToMovie(CurrentUserId));
                return RedirectToAction("Index");
            }
            return View(addMovieView);
        }
        
    }

    public static class MoviesExtensions
    {
        public static IEnumerable<MovieView> ToMoviesView(this List<Movie> movies, int userId)
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
                    CanVote = userId > 0 && movie.PostedBy.Id != userId,
                    PostedByYou = movie.PostedBy.Id == userId
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

            return age.Minutes > 1 ? $"{age.Minutes} minutes" : "less than a minute";
        }

        public static Movie ToMovie(this AddMovieView addMovieView, int userId)
        {
            var movie = new Movie
            {
                Title = addMovieView.Title,
                Description = addMovieView.Description,
                PostedByUserId = userId,
                PublishedDate = DateTime.Now
            };
            return movie;
        }
    }
}