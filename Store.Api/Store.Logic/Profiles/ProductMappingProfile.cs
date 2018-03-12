using System;
using AutoMapper;
using Store.DataAccess.Entities;
using Store.Models.Products;

namespace Store.Logic.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<GetAllProductsInput, ProductFilterInput>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>()
                .ForMember(x => x.Type, e => e.Ignore())
                .ForMember(x => x.Unit, e => e.Ignore())
                .ForMember(x => x.ProductCategory, e => e.Ignore());
            CreateMap<CreateProductDto, Product>()
                .ForMember(x => x.Id, e => e.Ignore())
                .ForMember(x => x.Type, e => e.Ignore())
                .ForMember(x => x.Unit, e => e.Ignore())
                .ForMember(x => x.ProductCategory, e => e.Ignore());
            CreateMap<Product, ProductDetailsDto>()
                .ForMember(x => x.ProductDescription, e => e.MapFrom(product => $"({product.Code}) {product.Description}"))
                .ForMember(x => x.Type, e => e.MapFrom(product => $"({product.Type.Code}) {product.Type.Description}"))
                .ForMember(x => x.Unit, e => e.MapFrom(product => $"({product.Unit.Code}) {product.Unit.Description}"))
                .ForMember(x => x.Price, e => e.MapFrom(product => product.Price.ToString("C2")))
                .ForMember(x => x.CategoriesCount, e => e.MapFrom(product => product.ProductCategory.Count))
                .ForMember(x => x.DeliveryDate, e => e.MapFrom(product => product.DeliveryDate.HasValue ? product.DeliveryDate.Value.ToString("dd.MM.yyyy") : String.Empty))
                .ForMember(x => x.IsAvailable, e => e.MapFrom(product => product.IsAvailable ? "Dostępny" : "Niedostępny"));
        }
    }
}