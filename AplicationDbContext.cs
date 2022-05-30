using FacturacionBell.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionBell
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Detalle> Detalle { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Factura> Factura { get; set; }



        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}
