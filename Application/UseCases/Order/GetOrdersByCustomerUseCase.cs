using Application.DTOs;
using Application.Mappers;
using Domain.Repository;

namespace Application.UseCases.Order
{
    public class GetOrdersByOrderUseCase
    {
        private readonly IOrderRepository _repository;

        public GetOrdersByOrderUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderDto>> Execute() => 
            (await _repository.GetAll()).Select(x => x.ToDto());

    }
}
