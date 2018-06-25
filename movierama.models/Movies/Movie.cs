using System;
using movierama.models.Voting;

namespace movierama.models.Movies
{
    public class Movie
    {
        public int Id { get; set; }
        
        public int PostedByUserId { get; set; }
        public Publisher PostedBy { get; set; }
        
        public Vote MyVote { get; set; }
        public bool HaveVoted => MyVote != No.Vote;
        
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool HasVotes => Likes > 0 || Hates > 0;
        public int Likes => Votes == No.Votes ? 0 : Votes.Likes;
        public int Hates => Votes == No.Votes ? 0 : Votes.Hates;
        public VoteResult Votes { get; set; }
    }
}