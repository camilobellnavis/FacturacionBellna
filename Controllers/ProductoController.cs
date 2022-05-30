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
    public class ProductoController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public ProductoController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listProducto = await _context.Producto.ToListAsync();
                return Ok(listProducto);
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
                var producto = await _context.Producto.FindAsync(id);

                if (producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<VueloController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Producto producto)
        {
            try
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();

                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<VueloController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Producto producto)
        {
            try
            {
                if (id != producto.id)
                {
                    return BadRequest();
                }
                _context.Update(producto);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Producto actualizado exitosamente!" });
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
                var producto = await _context.Producto.FindAsync(id);

                if (producto == null)
                {
                    return NotFound();
                }

                _context.Producto.Remove(producto);
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
