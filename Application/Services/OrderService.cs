using Application.DTOs;
using Application.UseCases.Order;
using Application.UseCases.Order;
using Application.UseCases.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Order;

namespace Application.Services
{
    public class OrderService
    {
        private readonly CreateOrderUseCase _createOrderUseCase;
        private readonly UpdateOrderUseCase _updateOrderUseCase;
        private readonly GetAllOrdersUseCase _getAllOrdersUseCase;
        private readonly GetOrdersWithProductsUseCase _getOrdersWithProductsUseCase;
        private readonly GetOrderUseCase _getOrderUseCase;
        private readonly AddProductUseCase _addProductUseCase;
        private readonly DeleteProductUseCase _deleteProductUseCase;

        public OrderService(
            CreateOrderUseCase createOrderUseCase,
            UpdateOrderUseCase updateOrderUseCase,
            GetAllOrdersUseCase getAllOrdersUseCase,
            GetOrdersWithProductsUseCase getOrdersWithProductsUseCase,
            GetOrderUseCase getOrderUseCase,
            AddProductUseCase addProductUseCase,
            DeleteProductUseCase deleteProductUseCase
            )
        {
            _createOrderUseCase = createOrderUseCase;
            _updateOrderUseCase = updateOrderUseCase;
            _getAllOrdersUseCase = getAllOrdersUseCase;
            _getOrdersWithProductsUseCase = getOrdersWithProductsUseCase;
            _getOrderUseCase = getOrderUseCase;
            _addProductUseCase = addProductUseCase;
            _deleteProductUseCase = deleteProductUseCase;
            _getOrderUseCase = getOrderUseCase;
        }

        public async Task<OrderDto?> GetOrder(int Id) => await _getOrderUseCase.Execute(Id);

        public async Task<IEnumerable<OrderDto>> GetOrders() => await _getAllOrdersUseCase.Execute();
        public async Task<IEnumerable<OrderDto>> GetOrdersWithProducts() => await _getOrdersWithProductsUseCase.Execute();

        public async Task<(bool existsCustomer, OrderDto? order)> AddOrder(OrderDto order) => await _createOrderUseCase.Execute(order);

        public async Task<(bool existe, OrderDto? order)> UpdateOrder(int id, OrderState state) => await _updateOrderUseCase.Execute(id, state);
        public async Task<OrderDto?> AddProductToOrder(int orderId, OrderProductPostDto orderProduct) => await _addProductUseCase.Execute(orderId, orderProduct);
        public async Task<OrderDto?> DeleteProductFromOrder(int orderId, int productId) => await _deleteProductUseCase.Execute(orderId, productId);
    }
}
