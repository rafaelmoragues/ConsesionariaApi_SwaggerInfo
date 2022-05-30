using System.ComponentModel.DataAnnotations;

namespace Consesionaria.Entity
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Importe { get; set; }
        public decimal Descuento { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public int VehiculoId { get; set; }
        public Vehiculo? Vehiculo { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
