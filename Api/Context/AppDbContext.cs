using Api.Model;
using Microsoft.EntityFrameworkCore;
using Api.Dtos;

namespace Api.Context
{
    public class AppDbContext : DbContext
    {



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Producto> producto { get; set; }

        public DbSet<Descuento> descuento { get; set; }

        public DbSet<ReseñaProducto> reseñaproducto { get; set; }
        public DbSet<Factura> facturas { get; set; }

        public DbSet<DetalleFactura> detallefactura { get; set; }
        public DbSet<clienteproducto> clientproducto { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Empleado> empleado { get; set; }
        public DbSet<Rol> rol { get; set; }
        public DbSet<Rolusuario> rolusuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de clave compuesta en la tabla de unión Rolusuario
            modelBuilder.Entity<Rolusuario>()
                .HasKey(ru => new { ru.Rol_idRol, ru.usuario_idUsuario });

            // Relación muchos a muchos entre Usuario y Rol a través de Rolusuario
            modelBuilder.Entity<Rolusuario>()
                .HasOne(ru => ru.Usuario)
                .WithMany(u => u.RolesUsuario)
                .HasForeignKey(ru => ru.usuario_idUsuario);

            modelBuilder.Entity<Rolusuario>()
                .HasOne(ru => ru.Rol)
                .WithMany(r => r.RolesUsuario)
                .HasForeignKey(ru => ru.Rol_idRol);

            // Relación uno a uno entre Usuario y Cliente
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Usuario)
                .WithOne(u => u.Cliente)
                .HasForeignKey<Cliente>(c => c.Usuario_idUsuario);

            // Relación uno a uno entre Usuario y Empleado
            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Usuario)
                .WithOne(u => u.Empleado)
                .HasForeignKey<Empleado>(e => e.Usuario_idUsuario);

            // Relación uno a muchos entre Factura y DetalleFactura
            modelBuilder.Entity<DetalleFactura>()
                .HasOne(d => d.Factura)
                .WithMany(f => f.DetallesFactura)
                .HasForeignKey(d => d.Factura_idFactura);

            // Relación uno a muchos entre Producto y DetalleFactura
            modelBuilder.Entity<DetalleFactura>()
                .HasOne(d => d.Producto)
                .WithMany(p => p.DetallesFactura)
                .HasForeignKey(d => d.Producto_idProducto);

            // Nuevas configuraciones

            // Relación muchos a muchos entre Cliente y Producto a través de ClienteProducto
            modelBuilder.Entity<clienteproducto>()
                .HasKey(cp => new { cp.cliente_idCliente, cp.producto_idProducto });

            modelBuilder.Entity<clienteproducto>()
                .HasOne(cp => cp.Cliente)
                .WithMany(c => c.Productos)
                .HasForeignKey(cp => cp.cliente_idCliente);

            modelBuilder.Entity<clienteproducto>()
                .HasOne(cp => cp.Producto)
                .WithMany(p => p.ClienteProductos)
                .HasForeignKey(cp => cp.producto_idProducto);

            // Relación uno a muchos entre Producto y Descuento
            modelBuilder.Entity<Descuento>()
                .HasOne(d => d.Producto)
                .WithMany(p => p.Descuentos)
                .HasForeignKey(d => d.producto_idProducto);

            // Relación uno a muchos entre Producto y ReseñaProducto
            modelBuilder.Entity<ReseñaProducto>()
                .HasOne(r => r.Producto)
                .WithMany(p => p.ReseñasProducto)
                .HasForeignKey(r => r.producto_idProducto);

            // Relación uno a muchos entre Cliente y ReseñaProducto
            modelBuilder.Entity<ReseñaProducto>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reseñas)
                .HasForeignKey(r => r.cliente_idCliente);
        }
        public DbSet<Api.Model.Servicio> Servicio { get; set; } = default!;





    }
}
