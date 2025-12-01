using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagement.Application.DTOs;
using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //Map DTO -> Entity
            CreateMap<ProductSaveDto, Product>();

            // Map Entity -> DTO
            CreateMap<Product, ProductResponseDto>();
        }
    }
}
