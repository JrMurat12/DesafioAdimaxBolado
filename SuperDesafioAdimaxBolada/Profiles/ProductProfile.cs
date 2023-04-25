using AutoMapper;
using SuperDesafioAdimaxBolada.Data.DTOs;
using SuperDesafioAdimaxBolada.Models;

namespace SuperDesafioAdimaxBolada.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDTO, Product>();
            CreateMap<Product, ReadProductDTO>()
                .ForMember(productDTO => productDTO.ProductsCategories,
                    opt => opt.MapFrom(product => product.ProductsCategories));
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<Product, UpdateProductDTO>();
            
        }
    }
}
