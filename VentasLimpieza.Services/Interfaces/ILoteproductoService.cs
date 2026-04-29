using VentasLimpieza.Core.Entities;
using VentasLimpieza.Core.QueryFilter;

namespace VentasLimpieza.Services.Interfaces
{
    public interface ILoteproductoService
    {
        Task<IEnumerable<Loteproducto>> GetAllLoteproductosAsync(LoteproductoQueryFilter? filters = null);
        Task<Loteproducto> GetLoteproductoByIdAsync(int id);
        Task RegistrarLoteproducto(Loteproducto loteproducto);
        void UpdateLoteproducto(Loteproducto loteproducto);
        Task DeleteLoteproducto(int id);
    }
}