using Application.DTOs;
using Domain.Entities;

namespace Application.Mappers
{
    public static class CustomerMapper
    {
        public static Customer? ToEntity (this CustomerDto dto)
        {
            if (dto is not null)
                return new Customer
                {
                    Id = dto.Id,
                    Email = dto.Email,
                    Name = dto.Name,
                    Address = dto.Address,
                    City = dto.City,
                    Country = dto.Country,
                    Phone = dto.Phone,
                    State = dto.State,
                };
            else
                return null;
        }

        public static Customer? ToEntity(this CustomerPostDto dto)
        {
            if (dto is not null)
                return new Customer
                {
                    Id = null,
                    Email = dto.Email,
                    Name = dto.Name,
                    Address = dto.Address,
                    City = dto.City,
                    Country = dto.Country,
                    Phone = dto.Phone,
                    State = dto.State,
                };
            else
                return null;
        }

        public static CustomerDto? ToDto(this Customer entity)
        {
            if (entity is not null)
                return new CustomerDto
                {
                    Id = entity.Id,
                    Email = entity.Email,
                    Name = entity.Name,
                    Address = entity.Address,
                    City = entity.City,
                    Country = entity.Country,
                    Phone = entity.Phone,
                    State = entity.State,
                };
            else
                return null;
        }
    }
}
