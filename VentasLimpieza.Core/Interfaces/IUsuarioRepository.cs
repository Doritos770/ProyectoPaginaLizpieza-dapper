using VentasLimpieza.Core.Entities;
using VentasLimpieza.Core.Interfaces;

namespace VentasLimpieza.core.Interfaces; 

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<IEnumerable<Usuario>> GetUsuarioByIdAsync(int id);
}