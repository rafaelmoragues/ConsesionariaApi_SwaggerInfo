using Consesionaria.Entity;
using Consesionaria.UOWork;
using Consesionaria.Responses;
using System.Security.Cryptography;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Consesionaria.Request;

namespace Consesionaria.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _uOW;
        private readonly IConfiguration _configuration;
        public UsuarioService(IUnitOfWork uow, IConfiguration configuration)
        {
            _uOW = uow;
            _configuration = configuration;
        }

        public UserResponse Login(string email, string password)
        {            
            if (_uOW.UsuarioRepo.ExisteUsuario(email))
            {
                UserResponse response = new UserResponse();
                Usuario user = _uOW.UsuarioRepo.GetByEmail(email);
                if(!VerificarPassword(password, user.PasswordHash, user.PasswordSalt))
                {
                    return null;
                }
                response.Email = email;
                response.Nombre = user.Nombre;
                response.FechaAlta = user.FechaAlta;
                response.Id = user.Id;
                return response;
            }
            return null;
        }
        private bool VerificarPassword(string pass, byte[] pHash, byte[] pSalt)
        {
            using (var hMac = new System.Security.Cryptography.HMACSHA512(pSalt))
            {
                var hash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
                for (var i = 0; i < hash.Length; i++)
                {
                    if (hash[i] != pHash[i]) return false;
                }
            }
            return true;
        }
        public UserResponse Registrar(UserRequest user, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CrearPassHash(password, out passwordHash, out passwordSalt);
            Usuario usuario = new Usuario();
            usuario.Nombre= user.Nombre;
            usuario.Email= user.Email;
            usuario.FechaAlta = DateTime.Now;
            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;
            _uOW.UsuarioRepo.Insert(usuario);
            _uOW.Save();
            UserResponse response = new UserResponse();
            response.Email = usuario.Email;
            response.Nombre = usuario.Nombre;
            response.FechaAlta = usuario.FechaAlta;
            response.Id = usuario.Id;
            return response;

        }
        private void CrearPassHash(string pass, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hMac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hMac.Key;
                passwordHash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
            }
            
        }

        public string GetToken(UserResponse usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.NameId, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, usuario.Nombre)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddMinutes(120),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token =tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

