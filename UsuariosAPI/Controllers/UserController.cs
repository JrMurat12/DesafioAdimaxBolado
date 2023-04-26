using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }


    [HttpPost]
    public async Task<IActionResult> InsertUser
        (CreateUserDTO userDTO)
    {
        await _userService.InsertUser(userDTO);
        return Ok("Usuário cadastrado!");

    }
}
