using Api.Context;
using Api.Dtos;
using Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Productoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductos()
        {
            // Obtener la lista de productos y proyectar a ProductoDTO
            return await _context.producto
                .Select(p => new ProductoDTO
                {
                    idProducto = p.idProducto,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    Stok = p.Stok,
                    Img = p.Img
                })
                .ToListAsync();
        }

        // GET: api/Productoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetProductoById(int id)
        {
            var producto = await _context.producto
                .Where(p => p.idProducto == id)
                .Select(p => new ProductoDTO
                {
                    idProducto = p.idProducto,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    Stok = p.Stok,
                    Img = p.Img
                })
                .FirstOrDefaultAsync();

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // POST: api/Productoes
        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> PostProducto(ProductoDTO productoDTO)
        {
            // Crear un nuevo producto basado en los datos del DTO
            var producto = new Producto
            {
                Nombre = productoDTO.Nombre,
                Descripcion = productoDTO.Descripcion,
                Precio = productoDTO.Precio,
                Stok = productoDTO.Stok,
                Img = productoDTO.Img
            };

            _context.producto.Add(producto);
            await _context.SaveChangesAsync();

            // Devolver el producto recién creado como ProductoDTO
            return CreatedAtAction("GetProductoById", new { id = producto.idProducto }, productoDTO);
        }

        // PUT: api/Productoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, ProductoDTO productoDTO)
        {
            if (id != productoDTO.idProducto)
            {
                return BadRequest("El ID del producto no coincide.");
            }

            var producto = await _context.producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            // Actualizar los campos del producto con los valores del DTO
            producto.Nombre = productoDTO.Nombre;
            producto.Descripcion = productoDTO.Descripcion;
            producto.Precio = productoDTO.Precio;
            producto.Stok = productoDTO.Stok;
            producto.Img = productoDTO.Img;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
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

        // DELETE: api/Productoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.producto.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return _context.producto.Any(e => e.idProducto == id);
        }
    }
}
