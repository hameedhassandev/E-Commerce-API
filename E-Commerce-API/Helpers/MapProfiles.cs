using AutoMapper;
using E_Commerce_API.DTOS;
using E_Commerce_API.Entities;
using E_Commerce_API.Identity;

namespace E_Commerce_API.Helpers
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            CreateMap<Product, ProductDto>()
            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.BrandName))
            .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.TypeName))
           /* .ForMember(d=>d.PictureUrl, o=>o.MapFrom<ProductUrlResolver>())*/;


            CreateMap<Address,AddressDto>().ReverseMap();

            CreateMap<UserBasketDto, Basket>().ReverseMap();

            CreateMap<BaskeItemDto, BaskeItem>().ReverseMap();

        }
    }
}
