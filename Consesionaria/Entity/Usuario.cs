using System.ComponentModel.DataAnnotations;

namespace Consesionaria.Entity
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public Role Role { get; set; }
    }
}
