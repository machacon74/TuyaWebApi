using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderProduct
    {
        public int? Id { get; set; }
        [ForeignKey("Order")]
        public int? IdOrder { get; set; }
        public int ProductId { get; set; } = 0;
        public string ProductName { get; set; }
        public int Quantity {  get; set; }
        public double Price { get; set; }
        public double Total => Quantity * Price;
        public Order Order { get; set; }
    }
}
