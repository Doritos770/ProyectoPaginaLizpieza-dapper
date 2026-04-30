using VentasLimpieza.Core.Entities;
using VentasLimpieza.Core.Interfaces;

namespace VentasLimpieza.core.Interfaces
{
    public interface ICodigoseguridadRepository : IBaseRepository<Codigoseguridad>
    {
        Task<IEnumerable<Codigoseguridad>> GetCodigoByUsuarioIdAsync(int usuarioId);
    }
}
