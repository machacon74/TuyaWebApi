using Domain.Entities;
using Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class OrderProductRepository : Repository<Order> , Domain.Repository.IOrderProductRepository
    {
        public OrderProductRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
