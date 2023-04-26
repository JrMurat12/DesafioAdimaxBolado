using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services;

public class UserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;

    public UserService(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task InsertUser(CreateUserDTO userDTO)
    {
        User user = _mapper.Map<User>(userDTO);

        IdentityResult result = await _userManager.CreateAsync(user, userDTO.Password);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar usuário!");
        }

    }
}
