using VentasLimpieza.Core.Entities;
using VentasLimpieza.Core.QueryFilter;

namespace VentasLimpieza.Services.Interfaces
{
    public interface IUsuarioService
    {
        //services va acciones de negocio
        Task<IEnumerable<Usuario>> GetAllUsersAsync(UsuarioQueryFilter? filters=null);//a todos
        Task<Usuario> GetUsuarioByIdAsync(int id);//con id
        Task RegistrarUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(int id);
        //Task<Usuario> GetUsuarioByEmail(string email);
        //Task<bool> EmailExists(string email);
    }
}
