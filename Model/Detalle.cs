using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionBell.Model
{
    public class Detalle
    {
        [Required]
        public int id { get; set; }
        [Required]
        public int id_factura { get; set; }
        [Required]
        public int id_producto { get; set; }
        [Required]
        public int precio { get; set; }
        [Required]
        public int cantidad { get; set; }
        [Required]
        public int importe { get; set; }
       
      
    }
}
