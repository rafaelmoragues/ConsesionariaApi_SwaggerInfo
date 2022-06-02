using Consesionaria.Entity;
using Consesionaria.UOWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consesionaria.Controllers
{
    /// <summary>
    /// Servicio para cargar, modificar u obtener vehiculos
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public VehiculoController(IUnitOfWork context)
        {
            _context = context;
        }
        /// <summary>
        /// Obtiene todos los vehiculos
        /// </summary>
        /// <returns>Todos los vehiculos</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Vehiculo>> Get()
        {
            var entidad = _context.VehiculoRepo.GetAll();
            return Ok(entidad);
        }
        /// <summary>
        /// Agrega un vehiculo a la base de datos
        /// </summary>
        /// <param name="vehiculo">Datos del Vehiculo</param>
        /// <returns>No devuelve nada</returns>
        [HttpPost]
        public ActionResult Post([FromBody] Vehiculo vehiculo)
        {
            _context.VehiculoRepo.Insert(vehiculo);
            _context.Save();
            return Ok();
        }

        /// <summary>
        /// Modifica los datos de un vehiculo
        /// </summary>
        /// <param name="vehiculo">Datos del Vehiculo</param>
        /// <param name="id">Id del vehiculo a modificar</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Vehiculo vehiculo, int id)
        {
            try
            {
                _context.VehiculoRepo.Update(vehiculo);
                _context.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Elimina un vehiculo de la base de datos
        /// </summary>
        /// <param name="id">Id del vehiculo a eliminar</param>
        /// <returns>Devuelve Ok</returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entity = _context.VehiculoRepo.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            _context.VehiculoRepo.Delete(id);
            _context.Save();

            return Ok();
        }
    }
}