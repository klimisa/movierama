using System;

namespace movierama.models
{
    public class VoteResult
    {
        public int MovieId { get; }

        public int Likes { get ; set; }
        public int Hates { get; set; }

        public VoteResult(int movieId)
        {
            if (movieId <= 0)
            {
                throw new ArgumentException(nameof(movieId));
            }

            MovieId = movieId;
        }

        public VoteResult(int movieId, int likes, int hates)
        {
            MovieId = movieId;
            Likes = likes;
            Hates = hates;
        }

        public void LikeMovie()
        {
            Likes += 1;
            if (Likes < 0)
            {
                Likes = 0;
            }
            
            Hates -= 1;
            if (Likes < 0)
            {
                Likes = 0;
            }
            
        }

        public void HateMovie()
        {
            Hates += 1;
            if (Likes < 0)
            {
                Likes = 0;
            }
            
            Likes -= 1;
            if (Likes < 0)
            {
                Likes = 0;
            }
        }
    }
}