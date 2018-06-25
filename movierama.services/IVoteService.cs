using movierama.models;
using movierama.models.Voting;

namespace movierama.services
{
    public interface IVoteService
    {
        Vote GetMovieVoteForUser(int movieId, int userId);
        VoteResult GetMovieVotes(int movieId);
        void LikeMovie(int movieId, int userId);
        void HateMovie(int movieId, int userId);
    }
}