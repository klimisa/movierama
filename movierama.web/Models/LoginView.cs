using System.ComponentModel.DataAnnotations;

namespace movierama.web.Models
{
    public class LoginView
    {
        [Required]
        [DataType(DataType.EmailAddress)]  
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]  
        public string Password { get; set; }
    }
}