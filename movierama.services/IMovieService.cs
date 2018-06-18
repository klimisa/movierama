using System.Collections.Generic;
using movierama.models;

namespace movierama.services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMoviesWithUserVote(int userId);
        void Add(Movie movie);
    }
}