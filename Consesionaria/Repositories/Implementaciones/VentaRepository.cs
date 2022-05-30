using Consesionaria.Data;
using Consesionaria.Entity;
using Consesionaria.Repositories.Interfaces;

namespace Consesionaria.Repositories.Implementaciones
{
    public class VentaRepository : GenericRepository<Venta>, IVentasRepository
    {
        public VentaRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
