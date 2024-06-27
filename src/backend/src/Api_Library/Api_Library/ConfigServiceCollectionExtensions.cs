using Api_Library.Interfaces;
using Api_Library.Interfaces.Services;
using Api_Library.Repository.Autor;
using Api_Library.Repository.Genero;
using Api_Library.Repository.Libros;
using Api_Library.Repository.Usuario;
using Api_Library.Service.Libro;
using Api_Library.Service.Usuario;

namespace Api_Library;

public static class ConfigServiceCollectionExtensions
{
    public static IServiceCollection AddMyDependecyGroup(this IServiceCollection services)
    {
        services.AddScoped<IAutorRepository, AutorRepository>();
        services.AddScoped<IGeneroRepository, GeneroRepository>();
        services.AddScoped<ILibrosRepository, LibroRepository>();
        services.AddScoped<ILibrosService, LibroService>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        return services;
    }
}