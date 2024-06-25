using Api_Library.Interfaces;
using Api_Library.Repository.Autor;
using Api_Library.Repository.Genero;

namespace Api_Library;

public static class ConfigServiceCollectionExtensions
{
    public static IServiceCollection AddMyDependecyGroup(this IServiceCollection services)
    {
        services.AddScoped<IAutorRepository, AutorRepository>();
        services.AddScoped<IGeneroRepository, GeneroRepository>();
        
        return services;
    }
}