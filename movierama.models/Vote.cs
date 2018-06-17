using System;

namespace movierama.models
{
    public class Vote
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public bool Like { get; set; }
    }
}