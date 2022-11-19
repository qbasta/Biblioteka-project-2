using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace Biblioteka_project_2.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [MaxLength(100)]
        [Display(Name = "Tytuł")]
        [Column(TypeName = "varchar(50)")]

        public string? TypeOfBook { get; set; }

        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Display(Name = "Rodzaj książki")]
        [Column(TypeName = "Kategoria")]

        public string? Autor { get; set; }

        [MaxLength(50)]
        [Display(Name = "Autor")]
        [Column(TypeName = "varchar(100)")]



        public string? Description { get; set; }

        [MinLength(20)]
        [MaxLength(1000)]
        [Display(Name = "Opis książki")]
        [Column(TypeName = "varchar(100)")]

        public string? ISBN { get; set; }
        [StringLength(13)]
        [Display(Name = "Numer ISBN")]
        [Column(TypeName = "varchar(13)")]


        public virtual ICollection<CategoryGroup>? CategoryGroups { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }

    }
}