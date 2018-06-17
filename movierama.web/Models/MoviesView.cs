using System.Collections.Generic;

namespace movierama.web.Models
{
    public class MoviesView
    {
        public IEnumerable<MovieView> Movies { get; set; }
    }

    public class MovieView
    {
        public string Title { get; set; }
        public UserView PostedBy { get; set; }
        public string TimePastSincePosted { get; set; }
        public string Description { get; set; }
        public bool HasVotes { get; set; }
        public bool CanVote { get; set; }
        public bool Hate { get; set; }
        public int Likes { get; set; }
        public bool Like { get; set; }
        public int Hates { get; set; }
        public bool HaveVoted { get; set; }
        public int Id { get; set; }
        public bool PostedByYou { get; set; }
    }

    public class UserView
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}