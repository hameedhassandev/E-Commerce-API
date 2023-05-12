using AutoMapper;
using E_Commerce_API.DTOS;
using E_Commerce_API.Entities;
using E_Commerce_API.Entities.Order;
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
            CreateMap<AddressDto, Entities.Order.address>();
            CreateMap<OrderDto, OrderReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeleveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeleveryMethod.Price));


            CreateMap<OrderItem, OrderItemsDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(i => i.ItemOrder.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(i => i.ItemOrder.ProductName));

        }
    }
}
