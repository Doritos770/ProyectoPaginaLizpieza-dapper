using Microsoft.EntityFrameworkCore;
using VentasLimpieza.core.Interfaces;
using VentasLimpieza.Core.Entities;
using VentasLimpieza.Core.Interfaces;
using VentasLimpieza.Infrastructure.Data;

namespace VentasLimpieza.Infrastructure.Repositories
{
    public class DetallepedidoRepository : BaseRepository<Detallepedido>, IDetallepedidoRepository
    {
        public DetallepedidoRepository(VentasLimpiezaContext context)
            : base(context)
        {
        }

    }
}
