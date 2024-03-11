using TrabajoFinalCoderHouse.Modelos;

namespace TrabajoFinalCoderHouse.Services
{
    public class VentaServices
    {
        public List<Venta> ListaVenta()
        {
            using (coderhouse context = new coderhouse())
            {
                List<Venta> ventas = context.Ventas.ToList();

                return ventas;
            }
        }

        internal static Venta ObtenerVentaPorId(int id)
        {
            using (coderhouse context = new coderhouse())
            {

                Venta? ventas = context.Ventas.Where(p => p.Id == id).FirstOrDefault();
                return ventas;
            }
        }

        internal static bool AgregarVenta(Venta ventas)
        {
            using (coderhouse context = new coderhouse())
            {
                context.Ventas.Add(ventas);

                context.SaveChanges();

                return true;
            }
        }

        internal static bool ActualizarVentaPorId(Venta ventas, int id)
        {
            using (coderhouse context = new coderhouse())
            {
                Venta? v = context.Ventas.Where(p => p.Id == id).FirstOrDefault();

                ventas.comentarioVenta = ventas.comentarioVenta;
                ventas.IdUsuario = ventas.IdUsuario;

                context.Ventas.Update(v);

                context.SaveChanges();
                return true;
            }
        }

        internal static void EliminarVenta(int id)
        {
            using (var context = new coderhouse())
            {

                var ventas = context.Ventas.Find(id);

                if (ventas == null)
                {
                    Console.WriteLine("Ese ID no existe");
                    return;
                }

                context.Ventas.Remove(ventas);

                context.SaveChanges();
            }
        }
    }
}
