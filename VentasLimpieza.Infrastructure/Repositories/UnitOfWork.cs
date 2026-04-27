using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using VentasLimpieza.core.Entities;
using VentasLimpieza.Core.Entities;
using VentasLimpieza.Core.Interfaces;
using VentasLimpieza.Infrastructure.Data;

namespace VentasLimpieza.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VentasLimpiezaContext _context;
        private readonly IBaseRepository<Pedido> _pedidoRepository;
        private readonly IBaseRepository<Categoria> _categoriaRepository;
        private readonly IBaseRepository<Direccion> _direccionRepository;
        private readonly IBaseRepository<Producto> _productoRepository;
        private readonly IBaseRepository<Resena> _resenaRepository;
        private readonly IBaseRepository<Usuario> _usuarioRepository;
        public UnitOfWork(VentasLimpiezaContext context)
        {
            _context = context;

        }
        public IBaseRepository<Pedido> PedidoRepository =>
            _pedidoRepository ?? new BaseRepository<Pedido>(_context);

        public IBaseRepository<Categoria> CategoriaRepository =>
            _categoriaRepository ?? new BaseRepository<Categoria>(_context);

        public IBaseRepository<Direccion> DireccionRepository =>
            _direccionRepository ?? new BaseRepository<Direccion>(_context);

        public IBaseRepository<Producto> ProductoRepository =>
            _productoRepository ?? new BaseRepository<Producto>(_context);

        public IBaseRepository<Resena> ResenaRepository =>
            _resenaRepository ?? new BaseRepository<Resena>(_context);

        public IBaseRepository<Usuario> UsuarioRepository =>
            _usuarioRepository ?? new BaseRepository<Usuario>(_context);

        public void Dispose()//liberacion de memoria o servicios
        {
            if(_context != null ) 
                _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        //en program.cs estara la inyeccion por dependencia
    }
}
