using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class OrderProductDto
    {
        public OrderProductDto()
        {
        }

        public int? Id { get; set; }
        public int IdOrder { get; set; }
        public int ProductId { get; set; } = 0;
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }
}
