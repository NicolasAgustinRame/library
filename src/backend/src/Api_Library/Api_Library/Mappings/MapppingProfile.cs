using Api_Library.Dtos;
using Api_Library.Model;
using AutoMapper;

namespace Api_Library.Mappings;

public class MapppingProfile : Profile
{
    public MapppingProfile()
    {
        CreateMap<Autor, AutorDto>();
        
        CreateMap<Genero, GeneroDto>();
        
        CreateMap<Libros, LibroDto>();

        CreateMap<Usuarios, UsuarioDto>();
    }
}