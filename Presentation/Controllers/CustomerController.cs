using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Services;
using Application.DTOs;
using Domain.Exceptions;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _service.GetCustomers();
            return Ok(customers);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _service.GetCustomer(id);
            if (customer == null)
                return NotFound("El cliente no existe.");
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerPostDto customer)
        {
            var newCustomer = await _service.AddCustomer(customer);
            return Ok(newCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDto customer)
        {
            // Uso de Exception
            if (id != customer.Id)
                return BadRequest("El ID de la URL y el del cuerpo no coinciden.");

            try
            {
                var updatedCustomer = await _service.UpdateCustomer(customer);
                return Ok(updatedCustomer);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
