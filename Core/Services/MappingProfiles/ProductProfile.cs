﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Shared;

namespace Services.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductResultDto>()
                .ForMember(d => d.BrandName, o => o.MapFrom(s => s.productBrand.Name))
                .ForMember(d => d.TypeName, o => o.MapFrom(s => s.productType.Name));
            CreateMap<ProductBrand,BrandResultDto>();
            CreateMap<ProductType,TypeResultDto>();
        }
    }
}
