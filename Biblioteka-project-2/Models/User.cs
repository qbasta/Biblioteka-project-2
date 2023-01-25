using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace Biblioteka_project_2.Models
{
    public class User : IdentityUser    
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? ProfilePicture { get; set; }

    }
}
