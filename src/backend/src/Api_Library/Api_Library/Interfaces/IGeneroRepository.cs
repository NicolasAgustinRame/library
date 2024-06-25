using Api_Library.Model;

namespace Api_Library.Interfaces;

public interface IGeneroRepository
{
    Task<List<Genero>> GetAll();
    Task<Genero> GetById(Guid id);
}