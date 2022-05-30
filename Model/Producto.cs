using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionBell.Model
{
    public class Producto
    {
        [Required]
        public int id { get; set; }
        [Required]
        public String nombre { get; set; }
        [Required]
        public Double precio { get; set; }
        [Required]
        public int stock { get; set; }
        
    }
}
