using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moj.DataImporter.Models;
using Moj.DataImporter.Models.Dto;

namespace Moj.DataImporter.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(o => o.ID, opt => opt.MapFrom(f => f.ID))
                .ForMember(o => o.ItemCode, opt => opt.MapFrom(f => f.Item.ItemCode))
                .ForMember(o => o.ColorCode, opt => opt.MapFrom(f => f.Item.ColorCode))
                .ForMember(o => o.Description, opt => opt.MapFrom(f => f.Item.Description))
                .ForMember(o => o.Price, opt => opt.MapFrom(f => f.Price))
                .ForMember(o => o.DiscountPrice, opt => opt.MapFrom(f => f.DiscountPrice))
                .ForMember(o => o.DeliverdIn, opt => opt.MapFrom(f => f.DeliveryPeriod.Period))
                .ForMember(o => o.Q1, opt => opt.MapFrom(f => f.Category.CategoryName))
                .ForMember(o => o.Size, opt => opt.MapFrom(f => f.Size))
                .ForMember(o => o.Color, opt => opt.MapFrom(f => f.Color.ColorName));
        }
    }
}
