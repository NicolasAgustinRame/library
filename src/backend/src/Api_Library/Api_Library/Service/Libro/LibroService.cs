using System.Net;
using Api_Library.Dtos;
using Api_Library.Interfaces;
using Api_Library.Interfaces.Services;
using Api_Library.Model;
using Api_Library.Query;
using Api_Library.Response;
using AutoMapper;

namespace Api_Library.Service.Libro;

public class LibroService : ILibrosService
{
    private readonly ILibrosRepository _librosRepository;
    private readonly IAutorRepository _autorRepository;
    private readonly IGeneroRepository _generoRepository;
    private readonly IMapper _mapper;

    public LibroService(ILibrosRepository librosRepository, IMapper mapper, IAutorRepository autorRepository, IGeneroRepository generoRepository)
    {
        _librosRepository = librosRepository;
        _mapper = mapper;
        _autorRepository = autorRepository;
        _generoRepository = generoRepository;
    }
    
    public async Task<ApiResponse<List<LibroDto>>> GetAll()
    {
        var response = new ApiResponse<List<LibroDto>>();
        var libro = await _librosRepository.GetAll();
        if (libro != null && libro.Count > 0)
        {
            response.Data = _mapper.Map<List<LibroDto>>(libro);
        }
        else {
            response.SetError("No hay libros en la base de datos", HttpStatusCode.NotFound);
        }
        return response;
    }

    public async Task<ApiResponse<LibroDto>> GetById(Guid id)
    {
        var response = new ApiResponse<LibroDto>();
        var libro = await _librosRepository.GetById(id);
        if (libro != null)
        {
            response.Data = _mapper.Map<LibroDto>(libro);
        } else {
            response.SetError("Libro no encotrado", HttpStatusCode.BadRequest);
        }
        return response;
    }

    public async Task<ApiResponse<LibroDto>> PostLibro(NewLibroQuery newLibroQuery)
    {
        var response = new ApiResponse<LibroDto>();
        if (newLibroQuery.Titulo == "" || newLibroQuery.Genero.ToString() == "" || newLibroQuery.Autor.ToString() == "" || newLibroQuery.FechaDePublicacion.ToString() == "")
        {
            response.SetError("Todos los campos son necesarios", HttpStatusCode.BadRequest);
            return response;
        }

        var exist = await _librosRepository.GetById(newLibroQuery.ISBN);
        if (exist != null)
        {
            response.SetError("El libro ya existe", HttpStatusCode.BadRequest);
            return response;
        }

        var genero = await _generoRepository.GetById(newLibroQuery.Genero);
        if (genero == null)
        {
            response.SetError("El genero no existe", HttpStatusCode.BadRequest);
            return response;
        }

        var autor = await _autorRepository.GetById(newLibroQuery.Autor);
        if (autor == null)
        {
            response.SetError("El autor no existe", HttpStatusCode.BadRequest);
            return response;
        }

        var nuevoLibro = new Libros()
        {
            ISBN = newLibroQuery.ISBN,
            Titulo = newLibroQuery.Titulo,
            Autor = autor,
            Genero = genero,
            FechaDePublicacion = newLibroQuery.FechaDePublicacion
        };

        nuevoLibro = await _librosRepository.PostLibros(nuevoLibro);
        response.Data = _mapper.Map<LibroDto>(nuevoLibro);
        return response;
    }

    public async Task<ApiResponse<LibroDto>> UpdateLibro(UpdateLibroQuery updateLibroQuery)
    {
        var response = new ApiResponse<LibroDto>();
        if (updateLibroQuery.Titulo == "" || updateLibroQuery.FechaDePublicacion.ToString() == "")
        {
            response.SetError("Todos los campos son necesarios", HttpStatusCode.BadRequest);
            return response;
        }
        
        var exist = await _librosRepository.GetById(updateLibroQuery.ISBN);
        if (exist == null)
        {
            response.SetError("El libro no existe", HttpStatusCode.BadRequest);
            return response;
        }

        var updateLibro = new Libros()
        {
            ISBN = updateLibroQuery.ISBN,
            Titulo = updateLibroQuery.Titulo,
            FechaDePublicacion = updateLibroQuery.FechaDePublicacion,
            Genero = exist.Genero,
            Autor = exist.Autor
        };

        updateLibro = await _librosRepository.UpdateLibros(updateLibro);
        response.Data = _mapper.Map<LibroDto>(updateLibro);

        return response;
    }

    public async Task<ApiResponse<LibroDto>> DeleteLibro(Guid ISBN)
    {
        var response = new ApiResponse<LibroDto>();
        var exist = await _librosRepository.GetById(ISBN);
        if (exist != null)
        {
            exist = await _librosRepository.DeleteLibros(ISBN);
            response.Data = _mapper.Map<LibroDto>(exist);
        }
        else {
            response.SetError("El libro no existe", HttpStatusCode.BadRequest);
        }

        return response;
    }
}