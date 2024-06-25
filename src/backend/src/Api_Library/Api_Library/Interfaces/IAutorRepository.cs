using Api_Library.Model;

namespace Api_Library.Interfaces;

public interface IAutorRepository
{
    Task<List<Autor>> GetAll();
    Task<Autor> GetById(Guid id);
}