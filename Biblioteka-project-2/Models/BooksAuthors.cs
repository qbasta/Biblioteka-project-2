using System.ComponentModel.DataAnnotations;

namespace Biblioteka_project_2.Models
{
    public class BooksAuthors
    {
        [Key]
        public int AuthorId { get; set; }

        public int BookId { get; set; }



    }
}
