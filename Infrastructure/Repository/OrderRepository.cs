using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class OrderRepository : Repository<Order> , Domain.Repository.IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<Order> AddProduct(int orderId, OrderProduct product)
        {
            var order = await _context.Orders.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == orderId);
            if (order == null)
                throw new EntityNotFoundException("La orden no existe.");
            else if (order.State == Order.OrderState.Cerrada)
                throw new EntityNotFoundException("La orden está cerrada.");
            else if (order.State == Order.OrderState.Cancelada)
                throw new EntityNotFoundException("La orden está cancelada.");

            order.Products.Add(product);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> DeleteProduct(int orderId, int productId)
        {
            var order = await _context.Orders.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == orderId);
            if (order == null)
                throw new EntityNotFoundException("La orden no existe.");
            else if (order.State == Order.OrderState.Cerrada)
                throw new EntityNotFoundException("La orden está cerrada.");
            else if (order.State == Order.OrderState.Cancelada)
                throw new EntityNotFoundException("La orden está cancelada.");

            var product = order.Products.FirstOrDefault(x => x.ProductId == productId);
            if (product == null)
                throw new EntityNotFoundException("El producto no existe en la orden.");
            order.Products.Remove(product);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetAllWithProducts()
        {
            return await _context.Orders.Include(x => x.Products).ToListAsync();
        }
    }
}
