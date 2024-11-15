using Api.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Agregar servicios al contenedor
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // Configurar las opciones de serialización JSON para manejar ciclos de referencia y mantener nombres originales
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // Evitar ciclos de referencia
                    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Mantener nombres de propiedad originales
                    options.JsonSerializerOptions.WriteIndented = true; // Formato legible (opcional)
                });

            // Agregar explorador de endpoints y Swagger para documentación
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configuración de la base de datos (MySQL)
            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(
                builder.Configuration.GetConnectionString("ConnectionString"),
                new MySqlServerVersion(new Version(8, 0, 21))
            ));

            // Configuración de CORS para permitir todas las solicitudes (útil durante el desarrollo)
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin() // Permitir cualquier origen
                           .AllowAnyMethod() // Permitir cualquier método HTTP
                           .AllowAnyHeader(); // Permitir cualquier encabezado
                });
            });

            var app = builder.Build();

            // Configurar el pipeline de solicitudes HTTP

            // Habilitar Swagger en todos los entornos
            app.UseSwagger();
            app.UseSwaggerUI();

            // Habilitar CORS
            app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Mapear controladores
            app.MapControllers();

            // Iniciar la aplicación
            app.Run();
        }
    }
}
