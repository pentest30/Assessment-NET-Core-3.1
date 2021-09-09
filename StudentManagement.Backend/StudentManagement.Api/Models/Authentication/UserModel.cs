using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Api.Models.Authentication
{
    public class UserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}