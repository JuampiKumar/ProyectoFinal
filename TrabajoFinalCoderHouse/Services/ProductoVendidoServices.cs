using TrabajoFinalCoderHouse.Database;
using TrabajoFinalCoderHouse.Modelos;

namespace TrabajoFinalCoderHouse.Services
{
    public class ProductoVendidoServices
    {
        private readonly coderhouse _context;

        public ProductoVendidoServices(coderhouse context)
        {
            this._context = context;
        }

        public List<ProductoVendido> ObtenerProductosVendidos()
        {
            return _context.ProductosVendidos.ToList();
        }

        public ProductoVendido ObtenerProductoVendidoPorId(int id)
        {
            return _context.ProductosVendidos.Where(p => p.idProductoVendido == id).FirstOrDefault();
        }

        public bool AgregarProductoVendido(ProductoVendido productoVendido)
        {
            _context.ProductosVendidos.Add(productoVendido);
            _context.SaveChanges();
            return true;
        }

        public bool ActualizarProductoVendido(ProductoVendido productoVendido, int id)
        {
            var productoVendidoEncontrado = _context.ProductosVendidos.Where(p => p.idProductoVendido == id).FirstOrDefault();

            if (productoVendidoEncontrado == null)
            {
                return false;
            }

            productoVendidoEncontrado.IdProducto = productoVendido.IdProducto;
            productoVendidoEncontrado.IdVenta = productoVendido.IdVenta;
            productoVendidoEncontrado.Stock = productoVendido.Stock;

            _context.ProductosVendidos.Update(productoVendidoEncontrado);
            _context.SaveChanges();
            return true;
        }

        public void EliminarProductoVendido(int id)
        {
            var productoVendido = _context.ProductosVendidos.Find(id);

            if (productoVendido != null)
            {
                _context.ProductosVendidos.Remove(productoVendido);
                _context.SaveChanges();
            }
        }

        public List<ProductoVendido> ObtenerProductosVendidosPorUsuario(int idUsuario)
        {
            return _context.ProductosVendidos.Where(pv => pv.idProductoVendido && pv.idVenta == idUsuario).ToList();
        }
    }
}
