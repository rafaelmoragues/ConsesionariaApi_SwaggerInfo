using Consesionaria.Data;
using Consesionaria.Entity;
using Consesionaria.Repositories.Interfaces;

namespace Consesionaria.Repositories.Implementaciones
{
    public class ClienteRepostory : GenericRepository<Cliente>, IClientesRepository
    {
        public ClienteRepostory(ApplicationDbContext db) : base(db)
        {

        }
    }
}
