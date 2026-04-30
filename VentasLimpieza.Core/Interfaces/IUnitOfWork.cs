using VentasLimpieza.core.Interfaces;
using VentasLimpieza.Core.Entities;


namespace VentasLimpieza.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IBaseRepository<Pedido> PedidoRepository { get; }
        IBaseRepository<Categoria> CategoriaRepository { get; }
        IBaseRepository<Direccion> DireccionRepository { get; }
        IBaseRepository<Resena> ResenaRepository { get; }
        IBaseRepository<Loteproducto> LoteproductoRepository { get; }



        IDetallepedidoRepository DetallepedidoRepository { get; }
        ICodigoseguridadRepository CodigoseguridadRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }//darle repository
        IProductoRepository ProductoRepository { get; }


        //ahora los commits
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
