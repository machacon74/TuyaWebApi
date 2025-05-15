using Application.DTOs;
using Application.Mappers;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Order
{
    public class GetAllOrdersUseCase
    {
        private readonly IOrderRepository _repository;

        public GetAllOrdersUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderDto>> Execute() => 
            (await _repository.GetAll()).Select(x => x.ToDto());

    }
}
