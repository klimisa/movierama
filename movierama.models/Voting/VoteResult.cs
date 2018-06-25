using System;

namespace movierama.models.Voting
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
//            Hates -= 1;
            Normalize();
        }


        public void HateMovie()
        {
            Hates += 1;
//            Likes -= 1;
            Normalize();
        }
        
        private void Normalize()
        {
            if (Likes < 0)
            {
                Likes = 0;
            }
            if (Hates < 0)
            {
                Hates = 0;
            }
        }
    }
}