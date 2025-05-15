using Application.DTOs;
using Application.Services;
using Application.UseCases.Customer;
using Domain.Repository;
using Infrastructure.DB;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Controllers;
using PruebasUnitarias.DB;

namespace PruebasUnitarias
{
    public class CustomerTests : IClassFixture<DBFixer>
    {
        private AppDbContext _context;
        private ICustomerRepository _customerRepository;
        private readonly CreateCustomerUseCase _createCustomerUseCase;
        private readonly UpdateCustomerUseCase _updateCustomerUseCase;
        private readonly GetAllCustomersUseCase _getAllCustomersUseCase;
        private readonly GetCustomerUseCase _getCustomerUseCase;
        private readonly CustomerService _customerService;
        private readonly CustomerController _customerController;

        public CustomerTests(DBFixer dBFixer)
        {
            _context = dBFixer.DbContext;
            _customerRepository = new CustomerRepository(_context);
            _createCustomerUseCase = new CreateCustomerUseCase(_customerRepository);
            _updateCustomerUseCase = new UpdateCustomerUseCase(_customerRepository);
            _getAllCustomersUseCase = new GetAllCustomersUseCase(_customerRepository);
            _getCustomerUseCase = new GetCustomerUseCase(_customerRepository);
            _customerService = new CustomerService(_createCustomerUseCase, _updateCustomerUseCase, _getAllCustomersUseCase, _getCustomerUseCase);
            _customerController = new CustomerController(_customerService);

        }

        [Fact]
        public async void GetAll()
        {
            var result = await _customerController.GetAllCustomers();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Save()
        {
            var customer = new CustomerPostDto
            {
                Name = "Test",
                Address = "Col",
                City = "Test",
                Country = "Test",
                Email = "Test",
                Phone = "Test",
                State = "Test"
            };
            var result = await _customerService.AddCustomer(customer);
            Assert.NotNull(result);
        }
    }
}