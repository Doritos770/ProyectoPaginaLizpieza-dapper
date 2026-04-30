using VentasLimpieza.core.Interfaces;
using VentasLimpieza.Core.Entities;
using VentasLimpieza.Core.Interfaces;
using VentasLimpieza.Infrastructure.Data;

namespace VentasLimpieza.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VentasLimpiezaContext _context;
        private readonly IBaseRepository<Pedido> _pedidoRepository;//----------hay que hacer
        private readonly IBaseRepository<Categoria> _categoriaRepository;//------------------van
        private readonly IBaseRepository<Direccion> _direccionRepository;
        // private readonly IBaseRepository<Producto> _productoRepository;
        private readonly IProductoRepository _productoRepository;  //----------------------van 
        private readonly IBaseRepository<Resena> _resenaRepository;
        //  private readonly IBaseRepository<Usuario> _usuarioRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IBaseRepository<Codigoseguridad> _codigoseguridadRepository;//------hay que hacer
        private readonly IBaseRepository<Detallepedido> _detallepedidoRepository;//-------hay que  hacer
        private readonly IBaseRepository<Loteproducto> _loteproductoRepository;//-------hay hacer
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

        public IProductoRepository ProductoRepository =>
            _productoRepository ?? new ProductoRepository(_context);

        public IBaseRepository<Resena> ResenaRepository =>
            _resenaRepository ?? new BaseRepository<Resena>(_context);

        //public IUsuarioRepository<Usuario> UsuarioRepository =>
        //    _usuarioRepository ?? new BaseRepository<Usuario>(_context);

        public IUsuarioRepository UsuarioRepository =>
            _usuarioRepository ?? new UsuarioRepository(_context);

        public IBaseRepository<Codigoseguridad> CodigoseguridadRepository =>
        _codigoseguridadRepository ?? new BaseRepository<Codigoseguridad>(_context);

        public IBaseRepository<Detallepedido> DetallepedidoRepository =>
        _detallepedidoRepository ?? new BaseRepository<Detallepedido>(_context);

        public IBaseRepository<Loteproducto> LoteproductoRepository =>
        _loteproductoRepository ?? new BaseRepository<Loteproducto>(_context);



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
