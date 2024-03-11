using TrabajoFinalCoderHouse.Modelos;
using TrabajoFinalCoderHouse.ModelosDTO;

namespace TrabajoFinalCoderHouse.Mappers
{
    public class ProductoMAPPER
    {
        public static Producto MappearAProducto(ProductoDto dto)
        {
            Producto producto = new Producto();
            producto.idProducto = dto.Id;
            producto.PrecioVenta = dto.PrecioVenta;
            producto.Stock = dto.Stock;
            producto.PrecioCosto = dto.Costo;
            producto.IdUsuario = dto.IdUsuario;
            return producto;
        }

        public static ProductoDto MappearADTO(ProductoDto producto)
        {
            ProductoDto dto = new ProductoDto();

            dto.Descripcion = dto.Descripcion;
            dto.Id = dto.Id;
            dto.PrecioVenta = dto.PrecioVenta;
            dto.Stock = dto.Stock;
            dto.Costo = dto.Costo;
            dto.IdUsuario = dto.IdUsuario;

            return dto;
        }
    }
}
