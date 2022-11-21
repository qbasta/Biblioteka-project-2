using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Linq;

namespace Biblioteka_project_2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string email { get; set; }

        [Display(Name = "Twój rok urodzenia")]
        [Column(TypeName = "varchar(100)")]
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }

        [Display(Name = "Twoje nazwisko (opcjonalne)")]
        [Column(TypeName = "varchar(100)")]
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; }

        public bool IsAdmin()
        {

            if (!this.email.StartsWith("Admin@"))
            {
                return false;
            }

            return true;
        }
    }
}
