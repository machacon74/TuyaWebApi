using Domain.Entities;
using Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CustomerRepository : Repository<Customer> , Domain.Repository.ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
