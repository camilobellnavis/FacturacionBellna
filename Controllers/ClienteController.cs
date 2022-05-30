using FacturacionBell.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionBell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public ClienteController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<VentasController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listCliente = await _context.Cliente.ToListAsync();
                return Ok(listCliente);
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
                var cliente = await _context.Cliente.FindAsync(id);

                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<VueloController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<VueloController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            try
            {
                if (id != cliente.id)
                {
                    return BadRequest();
                }
                _context.Update(cliente);
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
                var cliente = await _context.Detalle.FindAsync(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                _context.Detalle.Remove(cliente);
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
