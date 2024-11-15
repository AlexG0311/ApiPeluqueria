using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Context;
using Api.Model;
using Api.Dtos;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServiciosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Servicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetServicio()
        {
            return await _context.Servicio.ToListAsync();
        }

        // GET: api/Servicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> GetServicio(int id)
        {
            var servicio = await _context.Servicio.FindAsync(id);

            if (servicio == null)
            {
                return NotFound();
            }

            return servicio;
        }

        // PUT: api/Servicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicio(int id, ServicioEdit servicioEdit)
        {
            if (id != servicioEdit.idServicio)
            {
                return BadRequest("El ID del servicio no coincide.");
            }

            var servicioExistente = await _context.Servicio.FindAsync(id);
            if (servicioExistente == null)
            {
                return NotFound();
            }

            servicioExistente.Nombre = servicioEdit.Nombre;
            servicioExistente.Descripcion = servicioEdit.Descripcion;
            servicioExistente.Precio = servicioEdit.Precio;
            servicioExistente.Duracion = servicioEdit.Duracion;
            servicioExistente.Img = servicioEdit.Img;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Servicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Servicio>> PostServicio(ServicioDTO servicioDTO)
        {

            var servicio = new Servicio
            {
                Nombre = servicioDTO.Nombre,
                Descripcion = servicioDTO.Descripcion,
                Precio = servicioDTO.Precio,
                Duracion = servicioDTO.Duracion,
                Img = servicioDTO.Img
            };



            _context.Servicio.Add(servicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicio", new { id = servicio.idServicio }, servicio);
        }

        // DELETE: api/Servicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicio(int id)
        {
            var servicio = await _context.Servicio.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            _context.Servicio.Remove(servicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicioExists(int id)
        {
            return _context.Servicio.Any(e => e.idServicio == id);
        }
    }
}
