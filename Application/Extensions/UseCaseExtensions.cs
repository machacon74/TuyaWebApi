using Application.UseCases.Customer;
using Application.UseCases.Order;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddApplicationUseCases(this IServiceCollection services)
        {
            //Customer
            services.AddScoped<CreateCustomerUseCase>();
            services.AddScoped<GetAllCustomersUseCase>();
            services.AddScoped<GetCustomerUseCase>();
            services.AddScoped<UpdateCustomerUseCase>();

            //Order
            services.AddScoped<CreateOrderUseCase>();
            services.AddScoped<GetAllOrdersUseCase>();
            services.AddScoped<GetOrdersWithProductsUseCase>();
            services.AddScoped<GetOrdersByOrderUseCase>();
            services.AddScoped<GetOrderUseCase>();
            services.AddScoped<UpdateOrderUseCase>();
            services.AddScoped<AddProductUseCase>();
            services.AddScoped<DeleteProductUseCase>();

            return services;
        }
    }
}
