using System.ComponentModel.DataAnnotations;

namespace Biblioteka_project_2.Models.ShoppingCart
{
    public class CartDetail
    {
        public int Id { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int Amount { get; set; }

        public Book Book { get; set; }

        public ShoppingCart ShoppingCart { get; set; }



    }
}
