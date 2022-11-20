using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace Biblioteka_project_2.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
  
        [MaxLength(100)]    
        public string Title { get; set; }

        public string Category { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(100)")]
        public string Autor { get; set; }

        [MinLength(20)]
        [MaxLength(1000)]
        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }

        [StringLength(13)]
        [Column(TypeName = "varchar(13)")]
        public string ISBN { get; set; }
     
    }
}