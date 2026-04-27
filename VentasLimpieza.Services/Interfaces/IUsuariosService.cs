using System;
using System.Collections.Generic;
using System.Text;
using VentasLimpieza.core.Entities;
using VentasLimpieza.Core.EntidadesAux;
using VentasLimpieza.Core.Interfaces;
using VentasLimpieza.Core.UsuarioQueryFilter;

namespace VentasLimpieza.Services.Interfaces
{
    public interface IUsuarioService
    {
        //services va acciones de negocio
        Task<IEnumerable<Usuario>> GetAllUsersAsync(UsuarioQueryFilter? filters=null);//a todos
        Task<Usuario> GetUsuarioByIdAsync(int id);//con id
        Task RegistrarUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(int id);
        Task<SolicitarRecuperacionResponse> SolicitarCodigoRecuperacion(string email, string telefono);
        Task VerificarCodigoYCambiarContraseña(string email, string codigo, string nuevaContraseña);
        //Task<Usuario> GetUsuarioByEmail(string email);
        //Task<bool> EmailExists(string email);
    }
}
