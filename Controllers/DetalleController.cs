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
    public class DetalleController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public DetalleController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<VentasController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listDetalle = await _context.Detalle.ToListAsync();
                return Ok(listDetalle);
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
                var detalle = await _context.Detalle.FindAsync(id);

                if (detalle == null)
                {
                    return NotFound();
                }
                return Ok(detalle);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<VueloController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Detalle detalle)
        {
            try
            {
                _context.Add(detalle);
                await _context.SaveChangesAsync();

                return Ok(detalle);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<VueloController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Detalle detalle)
        {
            try
            {
                if (id != detalle.id)
                {
                    return BadRequest();
                }
                _context.Update(detalle);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Venta actualizado exitosamente!" });
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
                var detalle = await _context.Detalle.FindAsync(id);

                if (detalle == null)
                {
                    return NotFound();
                }

                _context.Detalle.Remove(detalle);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Ventas elminado exitosamente!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

