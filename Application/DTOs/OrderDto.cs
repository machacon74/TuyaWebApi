using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Order;

namespace Application.DTOs
{
    public class OrderDto
    {
        public int? Id { get; set; }
        public int IdCustomer { get; set; }
        public OrderState State { get; set; } = OrderState.Abierta;

        public List<OrderProductDto> Products { get; set; } = new();
        public double Total { get; set; } = 0;

    }
}
