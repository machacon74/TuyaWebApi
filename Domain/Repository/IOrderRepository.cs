using Domain.Entities;

namespace Domain.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Task<List<Order>> GetAllWithProducts();
        public Task<Order> AddProduct(int orderId, OrderProduct product);
        public Task<Order> DeleteProduct(int orderId, int idProduct);
    }
}