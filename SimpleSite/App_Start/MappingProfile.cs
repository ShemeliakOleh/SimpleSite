using AutoMapper;
using SimpleSite.Models;
using SimpleSite.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSite.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>().ForMember(dest => dest.Id,
                   opt => opt.MapFrom
                   (src => src.Id == null ? Guid.NewGuid() : src.Id));

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>().ForMember(dest => dest.Id,
                   opt => opt.MapFrom
                   (src => src.Id == null ? Guid.NewGuid() : src.Id));

            CreateMap<OrderProduct, OrderProductDto>();
            CreateMap<OrderProductDto, OrderProduct>().ForMember(dest => dest.Id,
                   opt => opt.MapFrom
                   (src => src.Id == null ? Guid.NewGuid() : src.Id));
        }
    }
}