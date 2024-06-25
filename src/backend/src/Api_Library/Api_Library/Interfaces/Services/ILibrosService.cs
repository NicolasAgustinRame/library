using Api_Library.Dtos;
using Api_Library.Model;
using Api_Library.Query;
using Api_Library.Response;

namespace Api_Library.Interfaces.Services;

public interface ILibrosService
{
    Task<ApiResponse<List<LibroDto>>> GetAll();
    Task<ApiResponse<LibroDto>> GetById(Guid id);
    Task<ApiResponse<LibroDto>> PostLibro(NewLibroQuery newLibroQuery);
    Task<ApiResponse<LibroDto>> UpdateLibro(UpdateLibroQuery updateLibroQuery);
    Task<ApiResponse<LibroDto>> DeleteLibro(Guid ISBN);
}