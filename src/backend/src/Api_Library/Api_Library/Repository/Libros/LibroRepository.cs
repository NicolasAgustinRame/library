using Api_Library.Data;
using Api_Library.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api_Library.Repository.Libros;

public class LibroRepository : ILibrosRepository
{
    private readonly ContextDb _contextDb;

    public LibroRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<Model.Libros>> GetAll()
    {
        var libros = await _contextDb.Libros
            .Include(l => l.Genero)
            .Include(l => l.Autor)
            .ToListAsync();
        return libros;  
    }

    public async Task<Model.Libros> GetById(Guid id)
    {
        var libro = await _contextDb.Libros
            .Include(l => l.Genero)
            .Include(l => l.Autor)
            .FirstOrDefaultAsync(l => l.ISBN == id);
        return libro;
    }

    public async Task<Model.Libros> PostLibros(Model.Libros newLibro)
    {
        await _contextDb.AddAsync(newLibro);
        await _contextDb.SaveChangesAsync();
        return newLibro;
    }

    public async Task<Model.Libros> UpdateLibros(Model.Libros updateLibro)
    {
        var libro = await _contextDb.Libros
            .Include(l => l.Genero)
            .Include(l => l.Autor)
            .FirstOrDefaultAsync(l => l.ISBN == updateLibro.ISBN);

        _contextDb.Update(libro);
        _contextDb.SaveChanges();
        return libro;
    }

    public async Task<Model.Libros> DeleteLibros(Guid id)
    {
        var libro = await _contextDb.Libros
            .Include(l => l.Genero)
            .Include(l => l.Autor)
            .FirstOrDefaultAsync(l => l.ISBN == id);

        _contextDb.Remove(libro);
        _contextDb.SaveChanges();
        return libro;
    }
}