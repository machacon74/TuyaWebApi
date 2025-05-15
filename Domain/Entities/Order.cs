using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : IEntity
    {
        public Order(OrderState state)
        {
            State = state;
        }

        public int? Id { get; set; }
        [ForeignKey("Customer")]
        public required int IdCustomer { get; set; }
        public OrderState State { get; private set; } = OrderState.Abierta;
        public List<OrderProduct> Products { get; set; } = [];
        public double Total => Products.Sum(x => x.Total);
        public Customer? Customer { get; set; }

        public void CloseOrder()
        {
            State = OrderState.Cerrada;
        }

        public void CancelOrder() 
        {
            State = OrderState.Cancelada;
        }
      
        public enum OrderState
        {
            Abierta,
            Cerrada,
            Cancelada
        }
    }
}
