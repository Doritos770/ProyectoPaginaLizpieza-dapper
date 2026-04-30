using VentasLimpieza.core.Interfaces;
using VentasLimpieza.Core.Entities;


namespace VentasLimpieza.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ///con unit of work orquesta todos los repositorios
        IBaseRepository<Pedido> PedidoRepository { get; }
        IBaseRepository<Categoria> CategoriaRepository { get; }
        IBaseRepository<Direccion> DireccionRepository { get; }
        //IBaseRepository<Producto> ProductoRepository { get; } //darle repository
        IProductoRepository ProductoRepository { get; }
        IBaseRepository<Resena> ResenaRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }//darle repository
        IBaseRepository<Codigoseguridad> CodigoseguridadRepository { get; }
        IBaseRepository<Detallepedido> DetallepedidoRepository { get; }//darle repository
        IBaseRepository<Loteproducto> LoteproductoRepository { get; }//darle repository
        //ahora los commits
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
