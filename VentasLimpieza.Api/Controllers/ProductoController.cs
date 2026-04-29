using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentasLimpieza.core.Dtos;
using VentasLimpieza.Core.Entities;
using VentasLimpieza.Core.QueryFilter;
using VentasLimpieza.Services.Interfaces;
using VentasLimpieza.Services.Validators;

namespace VentasLimpieza.Api.Controllers
{
    [Route("api/[controller]")] // api/producto
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IMapper _mapper;

        public ProductoController(
             IProductoService productoService,
             IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductoQueryFilter filters)
        {
            var productos = await _productoService.GetAllProductsAsync(filters);
            var productosDto = _mapper.Map<IEnumerable<ProductoDto>>(productos);
            return Ok(productosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null)
                return NotFound();
            var productoDto = _mapper.Map<ProductoDto>(producto);
            return Ok(productoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductoDto productoDto)
        {
            var producto = _mapper.Map<Producto>(productoDto);
            await _productoService.RegistrarProducto(producto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductoDto productoDto)
        {
            var producto = _mapper.Map<Producto>(productoDto);
            _productoService.UpdateProducto(producto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productoService.DeleteProducto(id);
            return Ok();
        }
    }

}
