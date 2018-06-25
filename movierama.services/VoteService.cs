using movierama.models;
using movierama.models.Voting;
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
                var newVote = new Vote(userId, movieId);
                if (like)
                {
                    newVote.LikeMovie();
                }
                else
                {
                    newVote.HateMovie();
                }
                
                _voteRepository.AddVote(newVote);
            }
            else
            {
                if (like)
                {
                    vote.LikeMovie();
                }
                else
                {
                    vote.HateMovie();
                }
                _voteRepository.UpdateVote(vote);    
            }

            var voteResult = GetMovieVotes(movieId);
            if (voteResult == No.Votes)
            {
                var newVoteResult = new VoteResult(movieId);
                if (like)
                {
                    newVoteResult.LikeMovie();
                }
                else
                {
                    newVoteResult.HateMovie();
                }
                _voteRepository.AddVoteResult(newVoteResult); 
            }
            else
            {
                if (like)
                {
                    voteResult.LikeMovie();
                }
                else
                {
                    voteResult.HateMovie();
                }
                _voteRepository.UpdateVoteResult(voteResult);
            }
        }
    }
}