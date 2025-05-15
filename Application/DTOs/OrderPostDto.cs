using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Order;

namespace Application.DTOs
{
    public class OrderPostDto
    {
        public int IdCustomer { get; set; }
        public OrderState State { get; private set; } = OrderState.Abierta;

        public List<OrderProductPostDto> Products { get; set; } = [];
        public double Total { get; set; } = 0;

    }
}
