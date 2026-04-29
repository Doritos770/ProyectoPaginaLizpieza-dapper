using System;
using System.Collections.Generic;
using System.Text;

namespace VentasLimpieza.Core.QueryFilter
{
    public class UsuarioQueryFilter
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? FechaRegistro { get; set; }
    }
}
