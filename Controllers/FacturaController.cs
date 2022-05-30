using FacturacionBell.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionBell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public FacturaController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listFactura = await _context.Factura.ToListAsync();
                return Ok(listFactura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<VueloController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var factura = await _context.Factura.FindAsync(id);

                if (factura == null)
                {
                    return NotFound();
                }
                return Ok(factura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<VueloController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Factura factura)
        {
            try
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();


                return Ok(factura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<VueloController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Factura factura)
        {
            try
            {
                if (id != factura.id)
                {
                    return BadRequest();
                }
                _context.Update(factura);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Factura actualizado exitosamente!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<VueloController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var factura = await _context.Factura.FindAsync(id);

                if (factura == null)
                {
                    return NotFound();
                }

                _context.Factura.Remove(factura);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Producto elminado exitosamente!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
