using Consesionaria.Entity;

namespace Consesionaria.Repositories.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Usuario GetByEmail(string email);
        bool ExisteUsuario(string email);
    }
}
