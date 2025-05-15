using Application.DTOs;
using Application.Mappers;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Order;

namespace Application.UseCases.Order
{
    public class DeleteProductUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteProductUseCase(IOrderRepository repository)
        {
            _orderRepository = repository;
        }
        public async Task<OrderDto> Execute(int orderId, int productId)
        {
            return (await _orderRepository.DeleteProduct(orderId, productId)).ToDto();
        }
    }

}
