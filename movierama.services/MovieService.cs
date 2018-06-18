using System.Collections.Generic;
using movierama.models;
using movierama.repositories;

namespace movierama.services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUserService _userService;
        private readonly IVoteService _voteService;

        public MovieService() : this(
            new MovieRepository(), new UserService(), new VoteService())
        {
        }

        public MovieService(
            IMovieRepository movieRepository,
            IUserService userService,
            IVoteService voteService)
        {
            _movieRepository = movieRepository;
            _userService = userService;
            _voteService = voteService;
        }

        public IEnumerable<Movie> GetMoviesWithUserVote(int userId)
        {
            var movies = _movieRepository.GetAll();
            foreach (var movie in movies)
            {
                var user = _userService.GetUser(movie.PostedByUserId);
                movie.PostedBy = user;

                if (userId > 0)
                {
                    var myVote = _voteService.GetMovieVoteForUser(movie.Id, userId);
                    movie.MyVote = myVote;
                }

                var votes = _voteService.GetMovieVotes(movie.Id);
                movie.Votes = votes;
            }

            return movies;
        }

        public void Add(Movie movie)
        {
            _movieRepository.Add(movie);
        }
    }
}