using Consesionaria.Entity;

namespace Consesionaria.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }
        public Role Role { get; set; }
    }
}
