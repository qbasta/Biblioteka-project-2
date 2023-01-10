using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka_project_2.Models
{
    public class Borrow
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public string? UserId { get; set; }

        public string? Title { get; set; }

        public string? Category { get; set; }

        public string? Autor { get; set; }

        public string? Description { get; set; }    

        public string? ISBN { get; set; }   

        public int ? Amount {get; set; }    

         

        public virtual Book? Book { get; set; }

        public virtual User? User { get; set; }
    }
}
