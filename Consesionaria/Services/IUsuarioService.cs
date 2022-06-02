using Consesionaria.Entity;
using Consesionaria.Request;
using Consesionaria.Responses;

namespace Consesionaria.Services
{
    public interface IUsuarioService
    {
        UserResponse Registrar(UserRequest usuario, string password);
        UserResponse Login(string email, string password);
        string GetToken(UserResponse usuario);
    }
}
