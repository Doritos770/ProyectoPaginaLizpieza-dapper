using Microsoft.EntityFrameworkCore;
using VentasLimpieza.core.Interfaces;
using VentasLimpieza.Core.Entities;
using VentasLimpieza.Core.Interfaces;
using VentasLimpieza.Infrastructure.Data;

namespace VentasLimpieza.Infrastructure.Repositories
{
    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
    {
       // public readonly VentasLimpiezaContext _productos;

        public ProductoRepository(VentasLimpiezaContext context) 
            : base(context)
        {
          //  _productos = productos;
        }
       
    }
}
