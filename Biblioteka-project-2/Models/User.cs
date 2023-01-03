using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;


namespace Biblioteka_project_2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}
