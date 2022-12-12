namespace Biblioteka_project_2.Models
{
    public class Borrow
    {
        public int BorrowId { get; set; }

        public int BookId { get; set; }

        public string UserId { get; set; }

        public virtual Book Book { get; set; }

        public virtual User User { get; set; }
    }
}
