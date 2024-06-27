using Api_Library.Model;

namespace Api_Library.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuarios> GetByEmailAndPassword(string email, string password);
}