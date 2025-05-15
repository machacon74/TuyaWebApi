using Application.DTOs;
using Application.Mappers;
using Domain.Entities;
using Domain.Repository;
using System.Reflection;
using static Domain.Entities.Order;

namespace Application.UseCases.Order
{
    public class UpdateOrderUseCase
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<(bool existe, OrderDto?)> Execute(int id, OrderState state)
        {
            var order = await _repository.GetById(id);
            if (order != null)
            {
                if (state == OrderState.Cerrada)
                    order.CloseOrder();
                else if (state == OrderState.Cancelada)
                    order.CancelOrder();
                return (true, (await _repository.Update(order)).ToDto());
            }
            else
                return (false, null);
        }

    }
}
