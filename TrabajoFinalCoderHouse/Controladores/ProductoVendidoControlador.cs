using Microsoft.AspNetCore.Mvc;
using TrabajoFinalCoderHouse.Mappers;
using TrabajoFinalCoderHouse.ModelosDTO;
using TrabajoFinalCoderHouse.Services;

namespace TrabajoFinalCoderHouse.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoVendidoControlador
    {
        private readonly ProductoVendidoServices _productoVendidoService;

        public ProductoVendidoControlador(ProductoVendidoServices productoVendidoService)
        {
            this._productoVendidoService = productoVendidoService;
        }

        [HttpGet("{idUsuario}")]
        public ActionResult<List<ProductoVendidoDto>> ObtenerProductosVendidosPorUsuario(int idUsuario)
        {
            var productosVendidos = _productoVendidoService.ObtenerProductosVendidosPorUsuario(idUsuario);

            if (productosVendidos == null)
            {
                return NotFound();
            }

            var productosVendidosDTO = new List<ProductoVendidoDto>();

            foreach (var productoVendido in productosVendidos)
            {
                productosVendidosDTO.Add(ProductoVendidoMAPPER.MappearAProductoVendidoDTO(productoVendido)); // Se utiliza el método MappearAProductoVendidoDTO
            }

            return Ok(productosVendidosDTO);
        }
    }
}
