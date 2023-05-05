using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }


    [HttpPost("Insert")]
    public async Task<IActionResult> InsertUser
        (CreateUserDTO userDTO)
    {
        await _userService.InsertUser(userDTO);
        return Ok("User done!");

    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync(UserLoginDTO loginDTO)
    {
        var token = await _userService.Login(loginDTO);
        return Ok(token);
    }
}
