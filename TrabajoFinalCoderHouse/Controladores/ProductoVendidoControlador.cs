using Microsoft.AspNetCore.Mvc;
using TrabajoFinalCoderHouse.Mappers;
using TrabajoFinalCoderHouse.ModelosDTO;
using TrabajoFinalCoderHouse.Services;

namespace TrabajoFinalCoderHouse.Controladores
{
    [ApiController]
    [Route("api/productosvendidos")]
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
                return NotFoundResult();
            }

            var productosVendidosDTO = new List<ProductoVendidoDto>();

            foreach (var productoVendido in productosVendidos)
            {
                productosVendidosDTO.Add(ProductoVendidoMAPPER.MappearAProductoVendidoDTO(productoVendido));
            }

            return OkObjectResult(productosVendidosDTO);
        }

        private ActionResult<List<ProductoVendidoDto>> OkObjectResult(List<ProductoVendidoDto> productosVendidosDTO)
        {
            throw new NotImplementedException();
        }

        private ActionResult<List<ProductoVendidoDto>> NotFoundResult()
        {
            throw new NotImplementedException();
        }
    }
}
