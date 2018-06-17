using System.Collections.Generic;
using System.Linq;
using movierama.models;

namespace movierama.repositories
{
    public class VoteRepository : IVoteRepository
    {
        private static readonly List<Vote> Votes = new List<Vote>
        {
            new Vote {MovieId = 1, UserId = 3, Like = true},
            new Vote {MovieId = 2, UserId = 3, Like = false}
        };

        private static readonly List<VoteResult> VoteResults = new List<VoteResult>
        {
            new VoteResult {MovieId = 1, Likes = 127, Hates = 4},
            new VoteResult {MovieId = 2, Likes = 19, Hates = 24},
            new VoteResult {MovieId = 3, Likes = 17, Hates = 1},
            new VoteResult {MovieId = 4, Likes = 3, Hates = 2}
        };

        public Vote GetUserVote(int movieId, int userId)
        {
            return Votes.SingleOrDefault(vote => vote.MovieId == movieId && vote.UserId == userId);
        }

        public VoteResult GetMovieVoteResult(int movieId)
        {
            return VoteResults.SingleOrDefault(voteResult => voteResult.MovieId == movieId);
        }

        public void UpdateVote(Vote vote)
        {
            var existingVote = GetUserVote(vote.MovieId, vote.UserId);
            existingVote.Like = vote.Like;
        }

        public void AddVote(Vote newVote)
        {
            Votes.Add(newVote);
        }
        
        public void UpdateVoteResult(VoteResult voteResult)
        {
            var existingVoteResult = GetMovieVoteResult(voteResult.MovieId);
            existingVoteResult.Likes = voteResult.Likes;
            existingVoteResult.Hates = voteResult.Hates;
        }

        public void AddVoteResult(VoteResult newVoteResult)
        {
            VoteResults.Add(newVoteResult);
        }
    }
}