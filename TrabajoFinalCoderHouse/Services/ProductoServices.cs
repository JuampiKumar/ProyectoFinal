using TrabajoFinalCoderHouse.Database;
using TrabajoFinalCoderHouse.Mappers;
using TrabajoFinalCoderHouse.Modelos;
using TrabajoFinalCoderHouse.ModelosDTO;
using TrabajoFinalCoderHouse.Mappers;

namespace TrabajoFinalCoderHouse.Services
{
    public class ProductoServices
    {
        internal static List<Producto> ListaProductos()
        {
            using (coderhouse context = new coderhouse())
            {
                List<Producto> productos = context.Productos.ToList();

                return productos;
            }
        }

        internal static Producto ObtenerProductoPorId(int id)
        {
            using (coderhouse context = new coderhouse())
            {

                Producto? productoEncontrado = context.Productos.Where(p => p.idProducto == id).FirstOrDefault();
                return productoEncontrado;
            }
        }


        internal bool AgregarProducto(ProductoDto dto)
        {
            using (coderhouse context = new coderhouse())
            {
                Producto p = ProductoMAPPER.MappearAProducto(dto);

                context.Productos.Add(p);
                context.SaveChanges();

                return true;
            }
        }

        internal static bool ActualizarProductoPorId(Producto producto, int id)
        {
            using (coderhouse context = new coderhouse())
            {
                Producto? productoBuscado = context.Productos.Where(p => p.IdProducto == id).FirstOrDefault();
                productoBuscado.Descripcion = producto.Descripcion;
                productoBuscado.PrecioCosto = producto.PrecioCosto;
                productoBuscado.PrecioVenta = producto.PrecioVenta;
                productoBuscado.Stock = producto.Stock;
                productoBuscado.IdUsuario = producto.IdUsuario;

                context.Productos.Update(productoBuscado);

                context.SaveChanges();
                return true;
            }
        }

        internal static void EliminarProducto(int idProducto)
        {
            using (var context = new coderhouse())
            {
                var producto = context.Productos.Find(idProducto);

                foreach (var venta in context.Ventas)
                {
                    context.Ventas.Remove(venta);
                }

                context.Productos.Remove(producto);

                context.SaveChanges();
            }
        }

        public bool BorrarProductoPorId(int id)
        {
            using (coderhouse context = new coderhouse())
            {
                Producto? producto = context.Productos.Where(p => p.IdProducto == id).FirstOrDefault();
                if (producto != null)
                {
                    context.Remove(producto);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool ActualizarProductoPorId(int id, ProductoDto productoDTO)
        {
            using (coderhouse context = new coderhouse())
            {
                Producto? producto = context.Productos.Where(p => p.IdProducto == id).FirstOrDefault();
                if (producto != null)
                {
                    producto.PrecioVenta = productoDTO.PrecioVenta;
                    producto.Stock = productoDTO.Stock;
                    producto.PrecioCosto = productoDTO.Costo;
                    producto.Descripcion = productoDTO.Descripcion;
                    producto.IdUsuario = productoDTO.IdUsuario;

                    context.Productos.Update(producto);
                    context.SaveChanges();

                    return true;
                }
                return false;
            }
        }
    }
}
