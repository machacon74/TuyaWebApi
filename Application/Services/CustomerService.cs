using Application.DTOs;
using Application.UseCases.Customer;
using Application.UseCases.Customer;
using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService
    {
        private readonly CreateCustomerUseCase _createCustomerUseCase;
        private readonly UpdateCustomerUseCase _updateCustomerUseCase;
        private readonly GetAllCustomersUseCase _getAllCustomersUseCase;
        private readonly GetCustomerUseCase _getCustomerUseCase;

        public CustomerService(
            CreateCustomerUseCase createCustomerUseCase,
            UpdateCustomerUseCase updateCustomerUseCase,
            GetAllCustomersUseCase getAllCustomersUseCase, 
            GetCustomerUseCase getCustomerUseCase
            )
        {
            _createCustomerUseCase = createCustomerUseCase;
            _updateCustomerUseCase = updateCustomerUseCase;
            _getAllCustomersUseCase = getAllCustomersUseCase;
            _getCustomerUseCase = getCustomerUseCase;
        }
        
        public async Task<CustomerDto?> GetCustomer(int Id) => await _getCustomerUseCase.Execute(Id);

        public async Task<IEnumerable<CustomerDto>> GetCustomers() => await _getAllCustomersUseCase.Execute();

        public async Task<CustomerDto?> AddCustomer(CustomerPostDto customer) => await _createCustomerUseCase.Execute(customer);

        public async Task<CustomerDto> UpdateCustomer(CustomerDto customer) => await _updateCustomerUseCase.Execute(customer);
    }
}
