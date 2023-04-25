using AutoMapper;
using SuperDesafioAdimaxBolada.Data.DTOs;
using SuperDesafioAdimaxBolada.Models;

namespace SuperDesafioAdimaxBolada.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryDTO, Category>();
        CreateMap<UpdateCategoryDTO, Category>();
        CreateMap<Category, UpdateCategoryDTO>();
        CreateMap<Category, ReadCategoryDTO>()
            .ForMember(categoryDTO => categoryDTO.ProductsCategories,
                    opt => opt.MapFrom(category => category.ProductsCategories));
    }
}
