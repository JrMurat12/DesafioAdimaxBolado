using AutoMapper;
using SuperDesafioAdimaxBolada.Data.DTOs;
using SuperDesafioAdimaxBolada.Models;

namespace SuperDesafioAdimaxBolada.Profiles;

public class ProductCategoryProfile : Profile
{
    public ProductCategoryProfile()
    {
        CreateMap<CreateProductCategoryDTO, ProductCategory>();
        CreateMap<ProductCategory, ReadProductCategoryDTO>();
    }
}
