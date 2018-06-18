using System.ComponentModel.DataAnnotations;

namespace movierama.web.Models
{
    public class AddMovieView
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        
        [StringLength(250, MinimumLength = 3)]
        [Required]
        public string Description { get; set; }
    }
}