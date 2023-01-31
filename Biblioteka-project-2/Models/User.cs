using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace Biblioteka_project_2.Models
{
    public class User : IdentityUser    
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }



    }
}
