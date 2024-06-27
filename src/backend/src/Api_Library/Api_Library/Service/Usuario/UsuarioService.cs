using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Api_Library.Dtos;
using Api_Library.Interfaces;
using Api_Library.Interfaces.Services;
using Api_Library.Model;
using Api_Library.Response;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace Api_Library.Service.Usuario;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IConfiguration configuration)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
        _configuration = configuration;
    }
    
    
    public async Task<ApiResponse<UsuarioDto>> LoginLibrary(string email, string password)
    {
        var response = new ApiResponse<UsuarioDto>();
        var usuario = await _usuarioRepository.GetByEmailAndPassword(email, password);
        if (usuario == null)
        {
            response.SetError("Usuario no encontrado", HttpStatusCode.BadRequest);
            return response;
        }
        var token = GenerateToken(usuario);

        response.Data = new UsuarioDto
        {
            Email = email,
            Password = password,
            Token = token
        };
        return response;
    }

    private string GenerateToken(Usuarios usu)
    {
        var claim = new[]
        {
            new Claim(ClaimTypes.Email, usu.Email),
            new Claim("Password", usu.Password),
            new Claim(ClaimTypes.Role, usu.Rol.Rol)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var securityToken = new JwtSecurityToken(
            claims: claim,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: credentials
            );

        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return token;
    }
    
}