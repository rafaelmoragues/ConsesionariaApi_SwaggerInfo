using Consesionaria.Data;
using Consesionaria.Entity;
using Consesionaria.Repositories.Interfaces;

namespace Consesionaria.Repositories.Implementaciones
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext db) : base(db)
        {
        }

        public Usuario GetByEmail(string email)
        {
            return _db.Usuarios.FirstOrDefault(a => a.Email == email);
        }
        public bool ExisteUsuario(string email)
        {
            return _db.Usuarios.Any(a => a.Email == email);
        }
    }
}
