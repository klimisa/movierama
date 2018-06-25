using System.Collections.Generic;
using System.Linq;
using movierama.models;

namespace movierama.repositories
{
    public class VoteRepository : IVoteRepository
    {
        private static readonly List<Vote> Votes = new List<Vote>
        {
            new Vote(3, 1, true),
            new Vote(3, 2, false)
        };

        private static readonly List<VoteResult> VoteResults = new List<VoteResult>
        {
            new VoteResult (1, 127, 4),
            new VoteResult (2, 19, 24),
            new VoteResult (3, 17, 1),
            new VoteResult (4, 3, 2)
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