using Application.DTOs;
using Application.Mappers;
using Domain.Repository;

namespace Application.UseCases.Order
{
    public class CreateOrderUseCase
    {
        private readonly IOrderRepository _repository;
        private readonly ICustomerRepository _customerRepository;

        public CreateOrderUseCase(IOrderRepository repository, ICustomerRepository customerRepository)
        {
            _repository = repository;
            _customerRepository = customerRepository;
        }
        public async Task<(bool existsCustomer, OrderDto? order)> Execute(OrderDto Order)
        {
            if (await _customerRepository.Exists(Order.IdCustomer))
            {
                Order.Id = null;
                Order.Products.ForEach(x => x.Id = null);
                return (true, (await _repository.Add(Order.ToOrder())).ToDto());
                
            }
            else
                return (false, null);
        }
    }
}
