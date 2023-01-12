using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System.ComponentModel;

namespace Biblioteka_project_2.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Te pole jest wymagane!")]
        [MaxLength(100)]
        [DisplayName("Tytuł")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Te pole jest wymagane!")]
        [DisplayName("Kategoria")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Te pole jest wymagane!")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Autor")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Te pole jest wymagane!")]
        [MinLength(20, ErrorMessage = "Minimalna długość opisu wynosi 20 znaków!")]
        [MaxLength(1000)]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Opis")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Te pole jest wymagane!")]
        [MinLength(10, ErrorMessage = "Minimalna długość ISBN to 10 znaków!")]
        [MaxLength(13, ErrorMessage = "Maksymalna długość ISBN to 13 znaków!")]
        [Column(TypeName = "varchar(13)")]
        public string ISBN { get; set; }
        
        [Required(ErrorMessage = "Te pole jest wymagane!")]
        [DisplayName("Ilość")]
        [Range(0,100, ErrorMessage = "Wartość nie może być ujemna!")]
        public int Amount { get; set; }

        [Required(AllowEmptyStrings = true)]

        public string? imgPath { get; set; } = "/images/covers/cover0.png";

        //public ICollection<CategoryGroup> CategoryGroups { get; set; }
    }
}