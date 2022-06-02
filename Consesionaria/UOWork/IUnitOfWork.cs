using Consesionaria.Repositories;
using Consesionaria.Repositories.Interfaces;

namespace Consesionaria.UOWork
{
    public interface IUnitOfWork : IDisposable
    {
        IClientesRepository ClienteRepo { get; }
        IVentasRepository VentaRepo { get; }
        IVehiculoRepository VehiculoRepo { get; }
        IUsuarioRepository UsuarioRepo { get; }
        void Save();
    }
}
