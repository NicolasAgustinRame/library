using Api_Library.Data;
using Api_Library.Interfaces;
using Api_Library.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_Library.Repository.Usuario;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ContextDb _contextDb;

    public UsuarioRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<Usuarios> GetByEmailAndPassword(string email, string password)
    {
        var usuario = await _contextDb.Usuarios
            .Include(u => u.Rol)
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        return usuario;
    }
}