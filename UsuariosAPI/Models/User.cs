using Microsoft.AspNetCore.Identity;

namespace UsuariosAPI.Models;

public class User : IdentityUser
{
    public DateTime DataNascimento { get; set; }
    public User() : base() { }
}
