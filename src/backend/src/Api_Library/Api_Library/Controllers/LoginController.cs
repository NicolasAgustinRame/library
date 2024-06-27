using Api_Library.Interfaces.Services;
using Api_Library.Query;
using Microsoft.AspNetCore.Mvc;

namespace Api_Library.Controllers;

public class LoginController : Controller
{
    private readonly IUsuarioService _usuarioService;

    public LoginController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("login/post")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query)
    {
        var response = await _usuarioService.LoginLibrary(query.email, query.password);
        return Ok(response);
    }
}