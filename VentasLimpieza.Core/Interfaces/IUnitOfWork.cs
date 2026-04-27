using System;
using System.Collections.Generic;
using System.Text;
using VentasLimpieza.core.Entities;
using VentasLimpieza.Core.Entities;

namespace VentasLimpieza.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ///con unit of work orquesta todos los repositorios
        IBaseRepository<Pedido> PedidoRepository { get; }
        IBaseRepository<Categoria> CategoriaRepository { get; }
        IBaseRepository<Direccion> DireccionRepository { get; }
        IBaseRepository<Producto> ProductoRepository { get; }
        IBaseRepository<Resena> ResenaRepository { get; }
        IBaseRepository<Usuario> UsuarioRepository { get; }
        //ahora los commits
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
