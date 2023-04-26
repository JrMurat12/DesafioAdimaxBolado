using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Models;
using AutoMapper;

namespace UsuariosAPI.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDTO, User>();
    }
}