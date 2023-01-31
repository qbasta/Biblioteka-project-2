using System.ComponentModel.DataAnnotations;

namespace Biblioteka_project_2.Models.ShoppingCart
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public Order Order { get; set; }
        public Book Book { get; set; }
    }
}
