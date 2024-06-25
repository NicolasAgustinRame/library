using Api_Library.Data;
using Api_Library.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api_Library.Repository.Genero;

public class GeneroRepository : IGeneroRepository
{
    private readonly ContextDb _contextDb;

    public GeneroRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<Model.Genero>> GetAll()
    {
        var generos = await _contextDb.Generos.ToListAsync();
        return generos;
    }

    public async Task<Model.Genero> GetById(Guid id)
    {
        var genero = await _contextDb.Generos.FirstOrDefaultAsync(g => g.Id == id);
        return genero;
    }
}