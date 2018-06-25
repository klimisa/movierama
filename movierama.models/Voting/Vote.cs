using System;

namespace movierama.models.Voting
{
    public class Vote
    {
        public int UserId { get; }
        public int MovieId { get; }
        public bool Like { get; set; }

        public Vote(int userId, int movieId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException(nameof(userId));
            }
            
            if (movieId <= 0)
            {
                throw new ArgumentException(nameof(movieId));
            }
            
            MovieId = movieId;
            UserId = userId;
        }
        
        public Vote(int userId, int movieId, bool like)
        {
            MovieId = movieId;
            UserId = userId;
            Like = like;
        }

        public void LikeMovie()
        {
            Like = true;
        }
        
        public void HateMovie()
        {
            Like = false;
        }
    }
}