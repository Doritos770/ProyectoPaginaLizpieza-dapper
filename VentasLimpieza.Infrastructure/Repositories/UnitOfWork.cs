using VentasLimpieza.core.Interfaces;
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
        private readonly IBaseRepository<Loteproducto> _loteproductoRepository;
        private readonly IBaseRepository<Resena> _resenaRepository;

        private readonly IDetallepedidoRepository _detallepedidoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly ICodigoseguridadRepository _codigoseguridadRepository;   

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
        public IBaseRepository<Resena> ResenaRepository =>
            _resenaRepository ?? new BaseRepository<Resena>(_context);
        





        public IBaseRepository<Loteproducto> LoteproductoRepository =>
         _loteproductoRepository ?? new BaseRepository<Loteproducto>(_context);
        public IUsuarioRepository UsuarioRepository =>
            _usuarioRepository ?? new UsuarioRepository(_context);

        public ICodigoseguridadRepository CodigoseguridadRepository =>
        _codigoseguridadRepository ?? new CodigoseguridadRepository(_context);

        public IProductoRepository ProductoRepository =>
            _productoRepository ?? new ProductoRepository(_context);

        public IDetallepedidoRepository DetallepedidoRepository =>
            _detallepedidoRepository ?? new DetallepedidoRepository(_context);




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
