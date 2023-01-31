using Biblioteka_project_2.Models.ShoppingCart;

namespace Biblioteka_project_2.Repositories
{
    public interface IUserOrderRepository
    {
        Task<IEnumerable<Order>> UserOrders();
    }
}
