using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionBell.Model
{
    public class Cliente
    {
        [Required]
        public int id { get; set; }
        [Required]
        public String nombre { get; set; }
        [Required]
        public String apellido { get; set; }
        [Required]
        public String direccion { get; set; }
        [Required]
        public String telefono { get; set; }
        [Required]
        public String email { get; set; }
        [Required]
        public int edad { get; set; }
    }
}
