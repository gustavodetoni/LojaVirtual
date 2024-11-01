using AutoMapper;
using MVPShop.ProductApi.Models;

namespace MVPShop.ProductApi.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeamento para Product (Request e Response)
        CreateMap<Product, ProductRequestDTO>().ReverseMap();
        CreateMap<Product, ProductResponseDTO>().ReverseMap();


        // Mapeamento para Category (Response)
        CreateMap<Category, CategoryResponseDTO>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
            .ReverseMap();

        // Mapeamento para CategoryRequestDTO (para criação de uma categoria)
        CreateMap<Category, CategoryRequestDTO>().ReverseMap();

    }
}