using System;
using System.Collections.Generic;
using System.Text;

namespace VentasLimpieza.Core.QueryFilter
{
    public class ProductoQueryFilter
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public int? CategoriaId { get; set; }
        public string? Marca { get; set; }
        public decimal? PrecioMin { get; set; }
        public decimal? PrecioMax { get; set; }
        public string? FechaCreacion { get; set; }
    }
}
