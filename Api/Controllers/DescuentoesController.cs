using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Context;
using Api.Model;
using Api.Dtos;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescuentoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DescuentoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Descuentoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DescuentoDTO>>> GetDescuentos()
        {
            var descuentos = await _context.descuento
                .Select(d => new DescuentoDTO
                {
                    IdDescuento = d.IdDescuento,
                    Porcentaje = d.Porcentaje,
              
                    FechaInicio = d.FechaInicio,
                    FechaFin = d.FechaFin,
                    producto_idProducto = d.producto_idProducto
                })
                .ToListAsync();

            return Ok(descuentos);
        }

        // GET: api/Descuentoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DescuentoDTO>> GetDescuento(int id)
        {
            var descuento = await _context.descuento
                .Where(d => d.IdDescuento == id)
                .Select(d => new DescuentoDTO
                {
                    IdDescuento = d.IdDescuento,
                    Porcentaje = d.Porcentaje,
                   
                    FechaInicio = d.FechaInicio,
                    FechaFin = d.FechaFin,
                    producto_idProducto = d.producto_idProducto
                })
                .FirstOrDefaultAsync();

            if (descuento == null)
            {
                return NotFound();
            }

            return Ok(descuento);
        }

        // PUT: api/Descuentoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDescuento(int id, DescuentoDTO descuentoDTO)
        {
            if (id != descuentoDTO.IdDescuento)
            {
                return BadRequest();
            }

            var descuento = await _context.descuento.FindAsync(id);
            if (descuento == null)
            {
                return NotFound();
            }

            // Validación de superposición de fechas
            var superposicion = await _context.descuento.AnyAsync(d =>
                d.producto_idProducto == descuentoDTO.producto_idProducto &&
                d.IdDescuento != id &&
                (
                    (descuentoDTO.FechaInicio >= d.FechaInicio && descuentoDTO.FechaInicio <= d.FechaFin) ||
                    (descuentoDTO.FechaFin >= d.FechaInicio && descuentoDTO.FechaFin <= d.FechaFin)
                )
            );

            if (superposicion)
            {
                return BadRequest("Ya existe un descuento activo para este producto en las fechas especificadas.");
            }

            // Actualizar propiedades del descuento
            descuento.Porcentaje = descuentoDTO.Porcentaje;
            descuento.FechaInicio = descuentoDTO.FechaInicio;
            descuento.FechaFin = descuentoDTO.FechaFin;
            descuento.producto_idProducto = descuentoDTO.producto_idProducto;

            _context.Entry(descuento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescuentoExists(id))
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

        // POST: api/Descuentoes
        [HttpPost]
        public async Task<ActionResult<DescuentoDTO>> PostDescuento(DescuentoDTO descuentoDTO)
        {
            // Validación de superposición de fechas
            var superposicion = await _context.descuento.AnyAsync(d =>
                d.producto_idProducto == descuentoDTO.producto_idProducto &&
                (
                    (descuentoDTO.FechaInicio >= d.FechaInicio && descuentoDTO.FechaInicio <= d.FechaFin) ||
                    (descuentoDTO.FechaFin >= d.FechaInicio && descuentoDTO.FechaFin <= d.FechaFin)
                )
            );

            if (superposicion)
            {
                return BadRequest("Ya existe un descuento activo para este producto en las fechas especificadas.");
            }

            var descuento = new Descuento
            {
                Porcentaje = descuentoDTO.Porcentaje,
    
                FechaInicio = descuentoDTO.FechaInicio,
                FechaFin = descuentoDTO.FechaFin,
                producto_idProducto = descuentoDTO.producto_idProducto
            };

            _context.descuento.Add(descuento);
            await _context.SaveChangesAsync();

            descuentoDTO.IdDescuento = descuento.IdDescuento;
            return CreatedAtAction(nameof(GetDescuento), new { id = descuento.IdDescuento }, descuentoDTO);
        }

        // DELETE: api/Descuentoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDescuento(int id)
        {
            var descuento = await _context.descuento.FindAsync(id);
            if (descuento == null)
            {
                return NotFound();
            }

            _context.descuento.Remove(descuento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DescuentoExists(int id)
        {
            return _context.descuento.Any(e => e.IdDescuento == id);
        }
    }
}
