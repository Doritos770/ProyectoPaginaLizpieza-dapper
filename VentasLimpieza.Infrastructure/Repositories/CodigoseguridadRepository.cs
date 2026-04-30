
using Microsoft.EntityFrameworkCore;
using VentasLimpieza.core.Interfaces;
using VentasLimpieza.Core.Entities;
using VentasLimpieza.Core.Interfaces;
using VentasLimpieza.Infrastructure.Data;

namespace VentasLimpieza.Infrastructure.Repositories
{
    public class CodigoseguridadRepository : BaseRepository<Codigoseguridad>, ICodigoseguridadRepository
    {
        public CodigoseguridadRepository(VentasLimpiezaContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Codigoseguridad>> GetCodigoByUsuarioIdAsync(int usuarioId)
        {
            return await _entities
                .Where(c => c.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}