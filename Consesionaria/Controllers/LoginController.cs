using Consesionaria.Services;
using Consesionaria.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Consesionaria.Entity;
using Consesionaria.Repositories.Interfaces;
using Consesionaria.Request;
using Consesionaria.UOWork;
using Consesionaria.Responses;

namespace Consesionaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUnitOfWork _uow;

        public LoginController(IUsuarioService usuarioService, IUnitOfWork uow)
        {
            _usuarioService = usuarioService;
            _uow = uow;
        }
        [HttpPost]
        public ActionResult Login([FromBody] UserRequest req)
        {
            var response = _usuarioService.Login(req.Email, req.Password);
            if (response == null)
            {
                return Unauthorized();
            }
            var token = _usuarioService.GetToken(response);
            return Ok(new
            {
                token = token,
                usuario = response
            });
        }
        [HttpPost("Registro")]
        public ActionResult RegistrarUsuario([FromBody] UserRequest user)
        {
            if (_uow.UsuarioRepo.ExisteUsuario(user.Email.ToLower())){
                return BadRequest("Ya existe un cuenta asociada a ese Email");
            }
            UserResponse res = _usuarioService.Registrar(user, user.Password);
            return Ok(res);
        }
    }
}
