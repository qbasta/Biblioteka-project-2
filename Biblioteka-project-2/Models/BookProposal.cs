using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka_project_2.Models
{
    public class BookProposal
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Te pole jest wymagane!")]
        [MaxLength(100)]
        [DisplayName("Tytuł")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Te pole jest wymagane!")]
        [DisplayName("Kategoria")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "Te pole jest wymagane!")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Autor")]
        public string? Autor { get; set; }

        [Required(ErrorMessage = "Te pole jest wymagane!")]
        [MinLength(20, ErrorMessage = "Minimalna długość opisu wynosi 20 znaków!")]
        [MaxLength(1000)]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Opis")]
        public string? Description { get; set; }


       
    }
}

