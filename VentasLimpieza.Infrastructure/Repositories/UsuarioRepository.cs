using Microsoft.EntityFrameworkCore;
using VentasLimpieza.core.Interfaces;
using VentasLimpieza.Core.Entities;
using VentasLimpieza.Infrastructure.Data;

namespace VentasLimpieza.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        //public readonly VentasLimpiezaContext _usuario;

        public UsuarioRepository(VentasLimpiezaContext context)
            :base(context)
        {
          //  _usuario = usuario;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarioByIdAsync(int id)
        {
           return await _entities.Where(x => x.Id == id).ToListAsync();
           
        }
    }
}
