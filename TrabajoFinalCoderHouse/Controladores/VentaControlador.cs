using Microsoft.AspNetCore.Mvc;
using TrabajoFinalCoderHouse.Services;
using TrabajoFinalCoderHouse.Modelos;
using TrabajoFinalCoderHouse.Mappers;
using TrabajoFinalCoderHouse.ModelosDTO;


namespace TrabajoFinalCoderHouse.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaControlador
    {
        private readonly VentaServices _ventaService;

        public VentaControlador(VentaServices ventaService)
        {
            this._ventaService = ventaService;
        }

        [HttpGet]
        public List<Venta> ObtenerTodasLasVentas()
        {
            VentaServices ventaService = new VentaServices();
            return ventaService.ListaVenta();
        }


        [HttpGet("{id}")]
        public ActionResult<Venta> ObtenerVentaPorId(int id)
        {
            var venta = VentaServices.ObtenerVentaPorId(id);
            if (venta == null)
            {
                return NotFound();
            }
            return Ok(venta);
        }

        [HttpPost]
        public IActionResult AgregarVenta(VentaDto ventaDTO)
        {
            var venta = VentaMAPPER.MappearAVentas(ventaDTO);
            VentaServices.AgregarVenta(venta);
            return CreatedAtAction(nameof(ObtenerVentaPorId), new { id = venta.Id }, venta);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarVenta(int id, VentaDto ventaDTO)
        {
            if (id != ventaDTO.Id)
            {
                return BadRequest();
            }

            var venta = VentaMAPPER.MappearAVentas(ventaDTO);
            VentaServices.ActualizarVentaPorId(venta, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarVenta(int id)
        {
            VentaServices.EliminarVenta(id);
            return NoContent();
        }
    }
}
