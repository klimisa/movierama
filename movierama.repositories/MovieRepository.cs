using System;
using System.Collections.Generic;
using movierama.models;
using movierama.models.Movies;

namespace movierama.repositories
{
    public class MovieRepository: IMovieRepository
    {
        private  static readonly List<Movie> Movies = new List<Movie>
        {
            new Movie
            {
                Id = 1, 
                Title = "The Empire Strikes Back",
                PostedByUserId = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse a arcu convallis, vehicula dui et, semper tortor. Donec eget tellus euismod, efficitur eros porttitor, ullamcorper nunc. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque faucibus commodo risus, vitae aliquet augue. Quisque tempus pulvinar lectus sit amet laoreet. Morbi et pretium nisl. Aliquam erat volutpat. Integer sed mi lacus. Nullam porttitor erat nec congue eleifend.",
                PublishedDate = DateTime.Now.AddDays(-5)
            },
            new Movie
            {
                Id = 2, 
                Title = "Prometheus",
                PostedByUserId = 2,
                Description = "Donec a tempor nisi, in blandit elit. Suspendisse at metus non tortor suscipit interdum placerat hendrerit lorem. Morbi condimentum porttitor felis, lobortis commodo lorem posuere nec. Vivamus ac imperdiet lectus. Vivamus sollicitudin massa nibh. Aliquam vestibulum hendrerit enim, vitae dapibus eros pulvinar sed. Quisque sollicitudin mollis quam a maximus. Maecenas vel orci vitae tortor gravida varius sed pretium nisl. Aliquam pretium, ligula at facilisis vestibulum, mi massa commodo ex, ac dignissim velit mi ut ante. Maecenas lobortis venenatis odio at bibendum.",
                PublishedDate = DateTime.Now.AddDays(-2)
            },
            new Movie
            {
                Id = 3, 
                Title = "Alien",
                PostedByUserId = 1,
                Description = "Etiam venenatis eleifend eros faucibus sollicitudin. Phasellus laoreet felis purus, quis ultrices enim egestas sed. Aliquam tristique ipsum a cursus interdum. Duis sodales est vitae justo finibus, non tincidunt neque bibendum. Nam et risus molestie, posuere felis a, bibendum justo. Morbi congue, augue vel commodo varius, nulla ligula eleifend libero, id sollicitudin sem risus quis odio. Suspendisse vel est placerat, dictum augue sit amet, commodo turpis. Sed orci magna, finibus vitae euismod venenatis, vulputate sed lectus.",
                PublishedDate = DateTime.Now.AddDays(-15)
            },
            new Movie
            {
                Id = 4, 
                Title = "Sunshine",
                PostedByUserId = 3,
                Description = "Donec interdum lectus euismod, ullamcorper justo quis, aliquam magna. Proin tristique mattis eleifend. Nunc magna lacus, convallis sit amet ornare in, facilisis non ante. Pellentesque egestas id elit ac tempus. Fusce vel purus elit. Donec eu lobortis nulla. Nullam elementum quam in maximus commodo. Ut egestas hendrerit felis sed venenatis. Donec dignissim convallis magna posuere vehicula. Nullam vitae urna mollis, facilisis mi a, venenatis tortor. Etiam cursus fermentum enim, sed luctus nisl semper a. In sit amet nulla ultricies, dignissim erat nec, faucibus urna. Morbi id placerat purus, sit amet molestie quam.",
                PublishedDate = DateTime.Now.AddHours(-2)
            },
            new Movie
            {
                Id = 5, 
                Title = "Sunshine",
                PostedByUserId = 4,
                Description = "Donec interdum lectus euismod, ullamcorper justo quis, aliquam magna. Proin tristique mattis eleifend. Nunc magna lacus, convallis sit amet ornare in, facilisis non ante. Pellentesque egestas id elit ac tempus. Fusce vel purus elit. Donec eu lobortis nulla. Nullam elementum quam in maximus commodo. Ut egestas hendrerit felis sed venenatis. Donec dignissim convallis magna posuere vehicula. Nullam vitae urna mollis, facilisis mi a, venenatis tortor. Etiam cursus fermentum enim, sed luctus nisl semper a. In sit amet nulla ultricies, dignissim erat nec, faucibus urna. Morbi id placerat purus, sit amet molestie quam.",
                PublishedDate = DateTime.Now.AddDays(-7)
            }
        };
        public List<Movie> GetAll()
        {
            return Movies;
        }

        public void Add(Movie movie)
        {
            Movies.Add(movie);
        }
    }
}