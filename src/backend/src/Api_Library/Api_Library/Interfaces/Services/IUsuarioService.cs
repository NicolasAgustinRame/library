using Api_Library.Dtos;
using Api_Library.Response;

namespace Api_Library.Interfaces.Services;

public interface IUsuarioService
{
    Task<ApiResponse<UsuarioDto>> LoginLibrary(string email, string password);
}