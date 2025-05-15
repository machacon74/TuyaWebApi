using Application.DTOs;
using Domain.Entities;

namespace Application.Mappers
{
    public static class OrderMapper
    {
        public static Order? ToOrder (this OrderDto? dto)
        {
            if (dto is not null)
                return new Order(dto.State)
                {
                    Id = dto.Id,
                    IdCustomer = dto.IdCustomer,
                    Products = dto.Products.Select(p => p.ToOrderProduct()).ToList(),
                };
            else return null;
        }

        public static Order? ToOrder(this OrderPostDto? dto)
        {
            if (dto is not null)
                return new Order(dto.State)
                {
                    Id = null,
                    IdCustomer = dto.IdCustomer,
                    Products = dto.Products.Select(p => p.ToEntity()).ToList(),
                };
            else return null;
        }

        public static OrderDto? ToDto(this Order? entity)
        {
            if (entity is not null)
                return new OrderDto
                {
                    Id = entity.Id,
                    IdCustomer = entity.IdCustomer,
                    Products = entity.Products.Select(p => p.ToOrderProductDto()).ToList(),
                    State = entity.State,
                    Total = entity.Total,
                };
            else return null;
        }
    }
}
