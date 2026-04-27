using System;
using System.Collections.Generic;
using System.Text;

namespace VentasLimpieza.Core.UsuarioQueryFilter
{
    public class ProductoQueryFilter
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Marca { get; set; }
        public string? UsoEspecifico { get; set; }
        public string? Unidades { get; set; }
        public decimal? Precio { get; set; }
        public int? Cantidad { get; set; }
    }
}
