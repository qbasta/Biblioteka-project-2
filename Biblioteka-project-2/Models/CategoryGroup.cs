using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace Biblioteka_project_2.Models
{
    public class CategoryGroup
    {
        public int BookId { get; set; } //klucz obcy do Person
        public virtual Book? Book { get; set; }
        public int CategoryId { get; set; } //klucz obcy do Group
        public virtual Category? Category { get; set; }
    }
}