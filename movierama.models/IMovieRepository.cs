using System.Collections.Generic;

namespace movierama.models
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        void Add(Movie movie);
    }
}