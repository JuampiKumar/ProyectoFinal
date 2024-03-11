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
            return base.Ok(new { menssaje = "Hola desde producto", estado = 200 });
        }


        [HttpPost]
        public IActionResult AgregarUnNuevoProducto([FromBody] ProductoDto producto)
        {
            if (this.productoService.AgregarProducto(producto))
            {
                return base.Ok(new { mensaje = "PRODUCTO AGREGADO: ", producto });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se pudo agregar un producto" });
            }
        }

        [HttpDelete("{int id}")]
        public IActionResult BorrarProducto(int id)
        {
            if (id > 0)
            {
                if (this.productoService.BorrarProductoPorId(id))
                {
                    return base.Ok(new { mensaje = "Producto borrado", status = 200 });
                }
                else
                {
                    return base.Conflict(new { mensaje = "No se pudo borrar el producto" });
                }
            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser engativo" });
        }

        [HttpPut(template: "{id}")]
        public IActionResult ActualizarProductoPorId(int id, ProductoDTO productoDTO)
        {
            if (id > 0)
            {
                if (this.productoService.ActualizarProductoPorId(id, productoDTO))
                {
                    return base.Ok(new { mensaje = "Producto actualizado", status = 200, productoDTO });
                }
                return base.Conflict(new { mensaje = "No se pudo actualizar el producto" });
            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }
    }
}
