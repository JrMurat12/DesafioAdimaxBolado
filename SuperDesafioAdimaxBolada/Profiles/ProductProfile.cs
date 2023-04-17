using AutoMapper;
using SuperDesafioAdimaxBolada.Data.DTOs;
using SuperDesafioAdimaxBolada.Models;

namespace SuperDesafioAdimaxBolada.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDTO, Product>();
        CreateMap<UpdateProductDTO, Product>();
        CreateMap<Product, UpdateProductDTO>();
        CreateMap<Product, ReadProductDTO>();
    }
}
