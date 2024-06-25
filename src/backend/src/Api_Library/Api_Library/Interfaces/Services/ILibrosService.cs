using Api_Library.Dtos;
using Api_Library.Response;

namespace Api_Library.Interfaces.Services;

public interface ILibrosService
{
    Task<ApiResponse<List<LibroDto>>> GetAll();
}