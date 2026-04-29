using AutoMapper;
using VentasLimpieza.core.Dtos;
using VentasLimpieza.Core.Dtos;
using VentasLimpieza.Core.Entities;

namespace VentasLimpieza.Infrastructure.Mapping
{
    public class VentasLimpiezaProfile : Profile
    {
        public VentasLimpiezaProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();

            CreateMap < Categoria, CategoriaDto>();
            CreateMap<CategoriaDto, Categoria>();

            CreateMap<Direccion, DireccionDto>();
            CreateMap<DireccionDto, Direccion>();

            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoDto, ProductoDto>();

            CreateMap<Resena, ResenaDto>();
            CreateMap<ResenaDto, Resena>();

            CreateMap<Pedido, PedidoDto>();
            CreateMap<PedidoDto, Pedido>();

            CreateMap<Codigoseguridad, CodigoseguridadDto>();
            CreateMap<CodigoseguridadDto, Codigoseguridad>();

            CreateMap<Detallepedido, DetallepedidoDto>();
            CreateMap<DetallepedidoDto, Detallepedido>();

            CreateMap<Loteproducto, LoteproductoDto>();
            CreateMap<LoteproductoDto, Loteproducto>();
        }
    }
}
