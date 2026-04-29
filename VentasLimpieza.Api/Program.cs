using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VentasLimpieza.Api.Filters;
using VentasLimpieza.Core.Interfaces;
using VentasLimpieza.Infrastructure.Data;
using VentasLimpieza.Infrastructure.Mapping;
using VentasLimpieza.Infrastructure.Repositories;
using VentasLimpieza.Services.Interfaces;
using VentasLimpieza.Services.Services;
using VentasLimpieza.Services.Validators;

namespace VentasLimpieza.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddOpenApi();

            // Configurar BD
            var connectionString = builder.Configuration.GetConnectionString("ConnectionMySql");
            builder.Services.AddDbContext<VentasLimpiezaContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Registrar repositorios y servicios
            // builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>(); 

            builder.Services.AddTransient<IUsuarioService, UsuariosService>();
            builder.Services.AddTransient<IProductoService, ProductoService>();
            builder.Services.AddTransient<IDetallepedidoService, DetallepedidoService>();
            builder.Services.AddTransient<ILoteproductoService, LoteproductoService>();

            builder.Services.AddScoped(
                typeof(IBaseRepository<>), 
                typeof(BaseRepository<>));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            // Configurar Newtonsoft.Json para manejar ciclos de referencia
            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling
                        = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(VentasLimpiezaProfile).Assembly);

            // Validadores
            builder.Services.AddScoped<UsuarioDtoValidator>();

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            app.UseMiddleware<ExceptionHandlingMiddleware>(); 

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll"); 
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}