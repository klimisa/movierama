namespace movierama.models.Voting
{
    public interface IVoteRepository
    {
        Vote GetUserVote(int movieId, int userId);
        VoteResult GetMovieVoteResult(int movieId);
        void UpdateVoteResult(VoteResult voteResult);
        void AddVoteResult(VoteResult newVoteResult);
        void UpdateVote(Vote vote);
        void AddVote(Vote newVote);
    }
}