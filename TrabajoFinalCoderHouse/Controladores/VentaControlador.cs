using Microsoft.AspNetCore.Mvc;
using TrabajoFinalCoderHouse.Services;
using TrabajoFinalCoderHouse.Modelos;
using TrabajoFinalCoderHouse.Mappers;
using TrabajoFinalCoderHouse.ModelosDTO;

namespace TrabajoFinalCoderHouse.Controladores
{
    [ApiController]
    [Route("api/ventas")]
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
                return NotFoundResult();
            }
            return OkObjectResult(venta);
        }

        private ActionResult<Venta> OkObjectResult(Venta venta)
        {
            throw new NotImplementedException();
        }

        private ActionResult<Venta> NotFoundResult()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult AgregarVenta(VentaDto ventaDTO)
        {
            var venta = VentaMAPPER.MappearAVentas(ventaDTO);
            VentaServices.AgregarVenta(venta);
            return CreatedAtActionResult(nameof(ObtenerVentaPorId), new { id = venta.idVenta }, venta);
        }

        private IActionResult CreatedAtActionResult(string v, object value, Venta venta)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarVenta(int id, VentaDto ventaDTO)
        {
            if (id != ventaDTO.Id)
            {
                return BadRequestResult();
            }

            var venta = VentaMAPPER.MappearAVentas(ventaDTO);
            VentaServices.ActualizarVentaPorId(venta, id);
            return NoContentResult();
        }

        private IActionResult NoContentResult()
        {
            throw new NotImplementedException();
        }

        private IActionResult BadRequestResult()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarVenta(int id)
        {
            VentaServices.EliminarVenta(id);
            return NoContentResult();
        }
    }
}
