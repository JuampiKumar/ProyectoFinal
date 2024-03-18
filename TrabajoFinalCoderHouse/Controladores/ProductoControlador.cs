using Microsoft.AspNetCore.Mvc;
using TrabajoFinalCoderHouse.Services;
using TrabajoFinalCoderHouse.ModelosDTO;

namespace TrabajoFinalCoderHouse.Controladores
{
    [ApiController]
    [Route("api/productos")]
    public class ProductoControlador
    {
        private ProductoServices productoService;

        public ProductoControlador(ProductoServices productoService)
        {
            this.productoService = productoService;
        }


        [HttpGet]
        public IActionResult Index([FromQuery] string? nombre, [FromQuery] string? edad)
        {
            return OkObjectResult(new { menssaje = "Hola desde producto", estado = 200 });
        }

        private IActionResult OkObjectResult(object value)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult AgregarUnNuevoProducto([FromBody] ProductoDto producto)
        {
            if (this.productoService.AgregarProducto(producto))
            {
                return OkObjectResult(new {mensaje = "PRODUCTO AGREGADO: ", producto });
            }
            else
            {
                return ConflictObjectResult(new { mensaje = "No se pudo agregar un producto" });
            }
        }

        private IActionResult ConflictObjectResult(object value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{int id}")]
        public IActionResult BorrarProducto(int id)
        {
            if (id > 0)
            {
                if (this.productoService.BorrarProductoPorId(id))
                {
                    return OkObjectResult(new { mensaje = "Producto borrado", status = 200 });
                }
                else
                {
                    return ConflictObjectResult(new { mensaje = "No se pudo borrar el producto" });
                }
            }
            return BadRequestResult(new { status = 400, mensaje = "El id no puede ser engativo" });
        }

        private IActionResult BadRequestResult(object value)
        {
            throw new NotImplementedException();
        }

        [HttpPut(template: "{id}")]
        public IActionResult ActualizarProductoPorId(int id, ProductoDto productoDTO)
        {
            if (id > 0)
            {
                if (this.productoService.ActualizarProductoPorId(id, productoDTO))
                {
                    return OkObjectResult(new { mensaje = "Producto actualizado", status = 200, productoDTO });
                }
                return ConflictObjectResult(new { mensaje = "No se pudo actualizar el producto" });
            }
            return BadRequestResult(new { status = 400, mensaje = "El id no puede ser negativo" });
        }
    }
}
