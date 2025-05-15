using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Services;
using Application.DTOs;
using System.Timers;
using static Domain.Entities.Order;
using Domain.Exceptions;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService service)
        {
            _orderService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("WithProducts")]
        public async Task<IActionResult> GetOrdersWithProducts()
        {
            var orders = await _orderService.GetOrdersWithProducts();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetOrder(id);
            if (order == null)
                return NotFound("La orden no existe");
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto order)
        {
            //Tupla (bool, OrderDto)
            var (existsCustomer, newOrder) = await _orderService.AddOrder(order);
            if(existsCustomer)
                return Ok(newOrder);
            else 
                return NotFound("El cliente no existe");
        }

        [HttpPut("AddProduct/{orderId}")]
        public async Task<IActionResult> AddProductToOrder(int orderId, OrderProductPostDto orderProduct)
        {
            try
            {
                var order = await _orderService.AddProductToOrder(orderId, orderProduct);
                return Ok("Producto agregado.");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Conflict("Se ha presentado un error.");
            }
        }

        [HttpDelete("DeleteProduct/{orderId}")]
        public async Task<IActionResult> DeleteProductFromOrder(int orderId, int productId)
        {
            try
            {
                var order = await _orderService.DeleteProductFromOrder(orderId, productId);
                return Ok("Producto eliminado de la orden.");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Conflict("Se ha presentado un error.");
            }
        }

        [HttpPut("Close/{id}")]
        public async Task<IActionResult> CloseOrder(int id)
        {
            // Uso de tupla (bool, OrderDto)
            var (existe, order) = await _orderService.UpdateOrder(id, OrderState.Cerrada);
            if (!existe)
                return NotFound("La orden no existe.");

            return Ok("Orden cerrada exitosamente.");
        }

        [HttpPut("Cancell/{id}")]
        public async Task<IActionResult> CancellOrder(int id)
        {
            // Uso de tupla (bool, OrderDto)
            var (existe, order) = await _orderService.UpdateOrder(id, OrderState.Cancelada);
            if (!existe)
                return NotFound("La orden no existe.");

            return Ok("Orden cancelada exitosamente.");
        }
    }
}
