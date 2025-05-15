using Application.DTOs;
using Domain.Entities;

namespace Application.Mappers
{
    public static class OrderProductMapper
    {
        public static OrderProduct? ToOrderProduct(this OrderProductDto dto)
        {
            if (dto is not null)
                return new OrderProduct
                {
                    Id = dto.Id,
                    IdOrder = dto.IdOrder,
                    Quantity = dto.Quantity,
                    ProductName = dto.ProductName,
                    Price = dto.Price,
                    ProductId = dto.ProductId,
                };
            else
                return null;
        }

        public static OrderProduct? ToEntity(this OrderProductPostDto dto)
        {
            if (dto is not null)
                return new OrderProduct
                {
                    Id = null,
                    IdOrder = null,
                    Quantity = dto.Quantity,
                    ProductName = dto.ProductName,
                    Price = dto.Price,
                    ProductId = dto.ProductId,
                };
            else
                return null;
        }

        public static OrderProductDto? ToOrderProductDto(this OrderProduct entity)
        {
            if (entity is not null)
                return new OrderProductDto
                {
                    Id = entity.Id,
                    Quantity = entity.Quantity,
                    ProductName = entity.ProductName,
                    Price = entity.Price,
                    ProductId = entity.ProductId,
                    Total = entity.Total
                };
            else
                return null;
        }
    }
}
