using Api_Library.Model;

namespace Api_Library.Interfaces;

public interface ILibrosRepository
{
    Task<List<Libros>> GetAll();
    Task<Libros> GetById(Guid ISBN);
    Task<Libros> PostLibros(Libros newLibro);
    Task<Libros> UpdateLibros(Libros updateLibro);
    Task<Libros> DeleteLibros(Guid id);
}