using Consesionaria.Data;
using Consesionaria.Entity;
using Consesionaria.Repositories.Interfaces;

namespace Consesionaria.Repositories.Implementaciones
{
    public class VehiculoRepository : GenericRepository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
