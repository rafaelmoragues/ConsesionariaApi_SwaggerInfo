using Consesionaria.Validations;
using System.ComponentModel.DataAnnotations;

namespace Consesionaria.Entity
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Marca { get; set; }
        [Required]        
        public string? Modelo { get; set; }
        [TeslaCar(2009)]
        public int Año { get; set; }
        [Required]
        public double Importe { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaBaja { get; set; }
    }
}
