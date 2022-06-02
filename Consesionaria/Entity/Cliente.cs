using System.ComponentModel.DataAnnotations;

namespace Consesionaria.Entity
{
    public class Cliente
    {
        /// <summary>
        /// Id Identity, primary KEY
        /// </summary>
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Dni { get; set; }

        [Required]
        public string Direccion { get; set; }



    }
}
