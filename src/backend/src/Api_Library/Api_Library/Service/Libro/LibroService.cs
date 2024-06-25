using Api_Library.Dtos;
using Api_Library.Interfaces;
using Api_Library.Interfaces.Services;
using Api_Library.Response;
using AutoMapper;

namespace Api_Library.Service.Libro;

public class LibroService : ILibrosService
{
    private readonly ILibrosRepository _librosRepository;
    private readonly IMapper _mapper;

    public LibroService(ILibrosRepository librosRepository, IMapper mapper)
    {
        _librosRepository = librosRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<List<LibroDto>>> GetAll()
    {
        var response = new ApiResponse<List<LibroDto>>();
        var libro = await _librosRepository.GetAll();
        if (libro != null && libro.Count > 0)
        {
            response.Data = _mapper.Map<List<LibroDto>>(libro);
            return response;
        }
        return response;
    }
}