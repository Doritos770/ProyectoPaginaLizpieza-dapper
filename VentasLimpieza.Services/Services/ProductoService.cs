using VentasLimpieza.Core.Entities;
using VentasLimpieza.Core.Helpers;
using VentasLimpieza.Core.Interfaces;
using VentasLimpieza.Core.QueryFilter;
using VentasLimpieza.Services.Interfaces;

namespace VentasLimpieza.Services.Services
{
    public class ProductoService : IProductoService
    {
        public readonly IUnitOfWork _unitOfWork;

        public ProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Producto>> GetAllProductsAsync(ProductoQueryFilter? filters = null)
        {
            var productos = await _unitOfWork.ProductoRepository.GetAll();

            if (filters != null)
            {
                if (filters.Id.HasValue)
                {
                    productos = productos.Where(p => p.Id == filters.Id.Value);
                }
                if (!string.IsNullOrEmpty(filters.Nombre))
                {
                    productos = productos.Where(p => p.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                }
                if (filters.CategoriaId.HasValue)
                {
                    productos = productos.Where(p => p.CategoriaId == filters.CategoriaId.Value);
                }
                if (!string.IsNullOrEmpty(filters.Marca))
                {
                    productos = productos.Where(p => p.Marca != null && p.Marca.ToLower().Contains(filters.Marca.ToLower()));
                }
                if (filters.PrecioMin.HasValue)
                {
                    productos = productos.Where(p => p.Precio >= filters.PrecioMin.Value);
                }
                if (filters.PrecioMax.HasValue)
                {
                    productos = productos.Where(p => p.Precio <= filters.PrecioMax.Value);
                }
                if (!string.IsNullOrEmpty(filters.FechaCreacion))
                {
                    string fechaAux = Procesos.ParseFechaFlexible(filters.FechaCreacion);
                    if (fechaAux != null)
                    {
                        DateTime fechaFiltro = Convert.ToDateTime(fechaAux);
                        productos = productos.Where(p => p.FechaCreacion.ToDateTime(TimeOnly.MinValue).Date == fechaFiltro.Date);
                    }
                }
            }

            return productos;
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _unitOfWork.ProductoRepository.GetById(id);
        }

        public async Task RegistrarProducto(Producto producto)
        {
            await _unitOfWork.ProductoRepository.Add(producto);
            await _unitOfWork.SaveChangesAsync();
        }

        public void UpdateProducto(Producto producto)
        {
            _unitOfWork.ProductoRepository.Update(producto);
            _unitOfWork.SaveChanges();
        }

        public async Task DeleteProducto(int id)
        {
            await _unitOfWork.ProductoRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}