using TrabajoFinalCoderHouse.Modelos;
using TrabajoFinalCoderHouse.ModelosDTO;

namespace TrabajoFinalCoderHouse.Mappers
{
    public class ProductoVendidoMAPPER
    {
        public static ProductoVendidoDto MappearAProductoVendidoDTO(ProductoVendido productoVendido)
        {
            ProductoVendidoDto dto = new ProductoVendidoDto();
            dto.Id = productoVendido.IdProductoVendido;
            dto.IdProducto = productoVendido.IdProducto;
            dto.Stock = productoVendido.Stock;
            dto.IdVenta = productoVendido.IdVenta;

            return dto;
        }
    }
}
