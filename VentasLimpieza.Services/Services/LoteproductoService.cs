using VentasLimpieza.Core.Entities;
using VentasLimpieza.Core.Helpers;
using VentasLimpieza.Core.Interfaces;
using VentasLimpieza.Core.QueryFilter;
using VentasLimpieza.Services.Interfaces;

namespace VentasLimpieza.Services.Services
{
    public class LoteproductoService : ILoteproductoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoteproductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Loteproducto>> GetAllLoteproductosAsync(LoteproductoQueryFilter? filters = null)
        {
            var lotes = await _unitOfWork.LoteproductoRepository.GetAll();

            if (filters != null)
            {
                if (filters.Id.HasValue)
                {
                    lotes = lotes.Where(x => x.Id == filters.Id.Value);
                }
                if (filters.ProductoId.HasValue)
                {
                    lotes = lotes.Where(x => x.ProductoId == filters.ProductoId.Value);
                }
                if (!string.IsNullOrEmpty(filters.NumeroLote))
                {
                    lotes = lotes.Where(x => x.NumeroLote.ToLower().Contains(filters.NumeroLote.ToLower()));
                }
                if (!string.IsNullOrEmpty(filters.FechaFabricacion))
                {
                    string fechaAux = Procesos.ParseFechaFlexible(filters.FechaFabricacion);
                    if (fechaAux != null)
                    {
                        DateTime fechaFiltro = Convert.ToDateTime(fechaAux);
                        lotes = lotes.Where(x => x.FechaFabricacion.ToDateTime(TimeOnly.MinValue).Date == fechaFiltro.Date);
                    }
                }
                if (!string.IsNullOrEmpty(filters.FechaCaducidad))
                {
                    string fechaAux = Procesos.ParseFechaFlexible(filters.FechaCaducidad);
                    if (fechaAux != null)
                    {
                        DateTime fechaFiltro = Convert.ToDateTime(fechaAux);
                        lotes = lotes.Where(x => x.FechaCaducidad.ToDateTime(TimeOnly.MinValue).Date == fechaFiltro.Date);
                    }
                }
                if (filters.CantidadIngresoMin.HasValue)
                {
                    lotes = lotes.Where(x => x.CantidadIngreso >= filters.CantidadIngresoMin.Value);
                }
                if (filters.CantidadIngresoMax.HasValue)
                {
                    lotes = lotes.Where(x => x.CantidadIngreso <= filters.CantidadIngresoMax.Value);
                }
                if (filters.CantidadDisponibleMin.HasValue)
                {
                    lotes = lotes.Where(x => x.CantidadDisponible >= filters.CantidadDisponibleMin.Value);
                }
                if (filters.CantidadDisponibleMax.HasValue)
                {
                    lotes = lotes.Where(x => x.CantidadDisponible <= filters.CantidadDisponibleMax.Value);
                }
                if (filters.PrecioCompraMin.HasValue)
                {
                    lotes = lotes.Where(x => x.PrecioCompra >= filters.PrecioCompraMin.Value);
                }
                if (filters.PrecioCompraMax.HasValue)
                {
                    lotes = lotes.Where(x => x.PrecioCompra <= filters.PrecioCompraMax.Value);
                }
                if (!string.IsNullOrEmpty(filters.UbicacionAlmacen))
                {
                    lotes = lotes.Where(x => x.UbicacionAlmacen != null && x.UbicacionAlmacen.ToLower().Contains(filters.UbicacionAlmacen.ToLower()));
                }
                if (filters.Activo.HasValue)
                {
                    lotes = lotes.Where(x => x.Activo == filters.Activo.Value);
                }
            }

            return lotes;
        }

        public async Task<Loteproducto> GetLoteproductoByIdAsync(int id)
        {
            return await _unitOfWork.LoteproductoRepository.GetById(id);
        }

        public async Task RegistrarLoteproducto(Loteproducto loteproducto)
        {
            await _unitOfWork.LoteproductoRepository.Add(loteproducto);
            await _unitOfWork.SaveChangesAsync();
        }

        public void UpdateLoteproducto(Loteproducto loteproducto)
        {
            _unitOfWork.LoteproductoRepository.Update(loteproducto);
            _unitOfWork.SaveChanges();
        }

        public async Task DeleteLoteproducto(int id)
        {
            await _unitOfWork.LoteproductoRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}