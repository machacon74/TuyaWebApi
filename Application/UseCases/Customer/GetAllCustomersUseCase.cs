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
    public class GetAllCustomersUseCase
    {
        private readonly ICustomerRepository _repository;

        public GetAllCustomersUseCase(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerDto>> Execute() => 
            (await _repository.GetAll()).Select(x => x.ToDto());

    }
}
