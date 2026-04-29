using VentasLimpieza.Core.Entities;
using VentasLimpieza.Core.QueryFilter;

namespace VentasLimpieza.Services.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAllProductsAsync(ProductoQueryFilter? filters = null);
        Task<Producto> GetProductoByIdAsync(int id);
        Task RegistrarProducto(Producto producto);
        void UpdateProducto(Producto producto);
        Task DeleteProducto(int id);
    }
}
