using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services;

public class UserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;
    private TokenService _tokenService;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, TokenService tokenService = null)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _tokenService = tokenService;
    }

    public async Task InsertUser(CreateUserDTO userDTO)
    {
        User user = _mapper.Map<User>(userDTO);

        IdentityResult result = await _userManager.CreateAsync(user, userDTO.Password);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Failed to register user!");
        }

    }

    public async Task<string> Login(UserLoginDTO loginDTO)
    {
        var resultado = await _signInManager.PasswordSignInAsync(loginDTO.Username, loginDTO.Password, false, false);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Unauthenticated user!");
        }

        var user = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedUserName == loginDTO.Username.ToUpper());

        var token = _tokenService.GenerateToken(user);

        return token;
    }
}
