using Microsoft.Extensions.Hosting;
using System.Net;
using VentasLimpieza.Core.EntidadesAux;
using VentasLimpieza.Core.Entities;
using VentasLimpieza.Core.Exceptions;
using VentasLimpieza.Core.Helpers;
using VentasLimpieza.Core.Interfaces;
using VentasLimpieza.Core.QueryFilter;
using VentasLimpieza.Services.Interfaces;

namespace VentasLimpieza.Services.Services
{
    public class UsuariosService : IUsuarioService
    {
        
        //public readonly IBaseRepository<Usuario> _usuarioRepository;

        //public UsuariosService(IBaseRepository<Usuario> usuarioRepository)
        //{
        //    _usuarioRepository = usuarioRepository;
        //}
        public readonly IUnitOfWork _unitOfWork;
        public UsuariosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsersAsync(
            UsuarioQueryFilter? filters=null)  //------------------------ ver
        {
            //return await _usuarioRepository.GetAll();
              //    todos los repos  //todas las transacciones //elementos del CRUD
            //return await _unitOfWork.UsuarioRepository.GetAll();
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();
            if(filters != null)
            {

                if (filters.Email != null)
                {
                    usuarios = usuarios.Where(a => a.Email.ToLower().Contains(filters.Email.ToLower()));
                }
                if (filters.Apellido!= null)
                {
                    usuarios = usuarios.Where(a => a.Apellido.ToLower().Contains(filters.Apellido.ToLower()));
                }

                if (filters.Nombre != null)
                {
                    usuarios = usuarios.Where(a => a.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                } 
                if (filters.Telefono != null)
                {
                    usuarios = usuarios.Where(a => a.Telefono == filters.Telefono);
                }
                if (filters.FechaRegistro != null)
                {
                    string fechaAux =
                        Procesos.ParseFechaFlexible(filters.FechaRegistro);
                    if (fechaAux != null)
                    {
                        usuarios = usuarios.Where(x => x.FechaRegistro.ToShortDateString() ==
                        Convert.ToDateTime(fechaAux).ToShortDateString());
                    }
                }
            }
            return usuarios;
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            //return await _usuarioRepository.GetById(id);
            return await _unitOfWork.UsuarioRepository.GetById(id);
        }

        public async Task RegistrarUsuario(Usuario usuario)
        {
            await GetUsuarioByEmail(usuario.Email);
            await ValidateNoDuplicate(usuario);
            await ValidateTelefonoYaExistente(usuario.Telefono);
            //var user = await _usuarioRepository.GetById(usuario.Id);
            var user = await _unitOfWork.UsuarioRepository.GetById(usuario.Id);


            if (ContainsFobbidenWord(usuario.Apellido))
            {
                throw new Exception("Apellido no permitido");
            }
            if (ContainsFobbidenWord(usuario.Nombre))
            {
                throw new Exception("Nombre no permitido");
            }

            //await _usuarioRepository.Add(usuario);
            await _unitOfWork.UsuarioRepository.Add(usuario);
            await _unitOfWork.SaveChangesAsync();
        }



        public void UpdateUsuario(Usuario usuario)
        {
            //await _usuarioRepository.Update(usuario);
             _unitOfWork.UsuarioRepository.Update(usuario);
            _unitOfWork.SaveChangesAsync();

        }
        public async Task DeleteUsuario(int id)
        {
            //await _usuarioRepository.Delete(id);
            await _unitOfWork.UsuarioRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }



        //funciones auxiliares----------------------------------------------------------------------------

        private async Task GetUsuarioByEmail(string email)
        {
            //var usuarios = await _usuarioRepository.GetAll();
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();
            var existe = usuarios.Any(usuario => usuario.Email.Equals(email, StringComparison.OrdinalIgnoreCase));



            if (existe == true)
            {
                throw new Exception("Esta cuenta ya fue registrada con este email");
            }
        }

        private async Task ValidateNoDuplicate(Usuario usuario)
        {
            //var usuarios = await _usuarioRepository.GetAll();
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();

            // de aca es
            var existeMismaPersona = usuarios.Any(u =>
                u.Nombre.Equals(usuario.Nombre, StringComparison.OrdinalIgnoreCase) &&
                u.Apellido.Equals(usuario.Apellido, StringComparison.OrdinalIgnoreCase));

            if (existeMismaPersona)
                throw new Exception("Ya existe una cuenta registrada con este nombre y apellido");
        }
        public async Task ValidateTelefonoYaExistente(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return;

            //var usuarios = await _usuarioRepository.GetAll();
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();
            var existe = usuarios.Any(u => u.Telefono == telefono);

            if (existe)
                throw new Exception("Este número de telefono ya esta registrado");
        }

        private bool ContainsFobbidenWord(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            foreach (var word in ForbbidenWords)
            {
                if (text.Contains(word, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }
        public readonly string[] ForbbidenWords =
        {
            "pendejo", "pendeja","maricon", "marica", "culero", 
            "estupido", "estupida", "idiota", "imbecil", 
            "bastardo", "maldito", "maldita", "coño", "boludo", 
            "pelotudo", "concha", "pichula", "weon", "chucha", "mamaguevo",
            "baboso"
        };




    }

    
}
