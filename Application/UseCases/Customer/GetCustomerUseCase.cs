using Application.DTOs;
using Application.Mappers;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Customer
{
    public class GetCustomerUseCase
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerUseCase(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerDto?> Execute(int Id) => 
            (await _repository.GetById(Id)).ToDto();

    }
}
