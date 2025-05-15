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
    public class CreateCustomerUseCase
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerUseCase(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<CustomerDto?> Execute(CustomerPostDto customer)
        {
            return (await _repository.Add(customer.ToEntity())).ToDto();
        }
    }
}
