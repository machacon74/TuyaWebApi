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
    public class GetOrderUseCase
    {
        private readonly IOrderRepository _repository;

        public GetOrderUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderDto?> Execute(int Id) => 
            (await _repository.GetById(Id)).ToDto();

    }
}
