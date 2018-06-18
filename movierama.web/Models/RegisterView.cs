using System.ComponentModel.DataAnnotations;

namespace movierama.web.Models
{
    public class RegisterView
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string LastName { get; set; }
        
        [Required]  
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        
        [Required]  
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}