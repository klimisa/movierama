using movierama.models;
using movierama.repositories;

namespace movierama.services
{
    public class VoteService: IVoteService
    {
        private readonly IVoteRepository _voteRepository;

        public VoteService(): this(new VoteRepository())
        {
            
        }
        
        public VoteService(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository;
        }
        
        public Vote GetMovieVoteForUser(int movieId, int userId)
        {
            return _voteRepository.GetUserVote(movieId, userId);
        }

        public VoteResult GetMovieVotes(int movieId)
        {
            return _voteRepository.GetMovieVoteResult(movieId);
        }

        public void LikeMovie(int movieId, int userId)
        {
            SaveVote(movieId, userId, true);
        }

        public void HateMovie(int movieId, int userId)
        {
            SaveVote(movieId, userId, false);
        }
        
        private void SaveVote(int movieId, int userId, bool like)
        {
            var vote = GetMovieVoteForUser(movieId, userId);
            if (vote == No.Vote)
            {
                var newVote = new Vote
                {
                    MovieId = movieId,
                    UserId = userId,
                    Like = like
                };
                _voteRepository.AddVote(newVote);
            }
            else
            {
                vote.Like = like;
                _voteRepository.UpdateVote(vote);    
            }

            var voteResult = GetMovieVotes(movieId);
            if (voteResult == No.Votes)
            {
                var newVoteResult = new VoteResult
                {
                    MovieId = movieId,
                    Likes = like ? 1: 0,
                    Hates = !like ? 1: 0
                };
                _voteRepository.AddVoteResult(newVoteResult); 
            }
            else
            {
                voteResult.Likes = like ? voteResult.Likes + 1 : voteResult.Likes - 1;
                voteResult.Hates = !like ? voteResult.Hates + 1 : voteResult.Hates - 1;
                _voteRepository.UpdateVoteResult(voteResult);
            }
        }
    }
}