using System.Collections.Generic;
using movierama.models;

namespace movierama.services
{
    public interface IMovieService
    {
        List<Movie> GetMoviesWithUserVote(int userId);
    }
}