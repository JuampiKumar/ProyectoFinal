using TrabajoFinalCoderHouse.Modelos;
using TrabajoFinalCoderHouse.ModelosDTO;

namespace TrabajoFinalCoderHouse.Mappers
{
    public class VentaMAPPER
    {
        public static Venta MappearAVentas(VentaDto dto)
        {
            Venta ventas = new Venta();
            ventas.comentarioVenta = dto.Comentarios;
            ventas.IdUsuario = Convert.ToInt32(dto.IdUsuario);
            return ventas;
        }

        public static VentaDto MappearAVentasDTO(VentaDto ventas)
        {
            VentaDto dto = new VentaDto();
            dto.Comentarios = dto.Comentarios;
            dto.IdUsuario = dto.IdUsuario;

            return dto;
        }
    }
}
