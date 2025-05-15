using Application.DTOs;
using Application.Mappers;
using Domain.Exceptions;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Application.UseCases.Customer
{
    public class UpdateCustomerUseCase
    {
        private readonly ICustomerRepository _repository;

        public UpdateCustomerUseCase(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<CustomerDto?> Execute(CustomerDto customer)
        {
            var existe = await _repository.Exists(customer.Id);
            if (existe)
                return (await _repository.Update(customer.ToEntity())).ToDto();
            else
                throw new EntityNotFoundException("El cliente no existe.");
        }
    }
}
