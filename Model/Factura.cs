using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionBell.Model
{
    public class Factura
    {
        [Required]
        public int id { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        [Required]
        public int idcliente { get; set; }
       
    }
}
