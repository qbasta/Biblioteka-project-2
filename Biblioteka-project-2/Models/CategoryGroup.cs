using DocumentFormat.OpenXml.Drawing.Diagrams;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka_project_2.Models
{
    public class CategoryGroup
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; } //klucz obcy do Person
        public virtual Book? Book { get; set; }
        public int CategoryId { get; set; } //klucz obcy do Group
        public virtual Category? Category { get; set; }


    }
}