using Api_Library.Data;
using Api_Library.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api_Library.Repository.Autor;

public class AutorRepository : IAutorRepository
{
    private readonly ContextDb _contextDb;

    public AutorRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<Model.Autor>> GetAll()
    {
        var autor = await _contextDb.Autores.ToListAsync();
        return autor;
    }

    public async Task<Model.Autor> GetById(Guid id)
    {
        var autor = await _contextDb.Autores.FirstOrDefaultAsync(a => a.Id == id);
        return autor;
    }
}