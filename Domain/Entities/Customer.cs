using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : IEntity
    {
        public Customer()
        {
        }

        public Customer(string name, string email, string phone, string country, string state, string city, string address)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Country = country;
            State = state;
            City = city;
            Address = address;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public List<Order> Orders = new();
    }
}
