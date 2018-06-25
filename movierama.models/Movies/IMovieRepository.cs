using System.Collections.Generic;

namespace movierama.models.Movies
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        void Add(Movie movie);
    }
}