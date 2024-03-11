namespace TrabajoFinalCoderHouse.Modelos
{
    public class Producto
    {
        public int idProducto; //PODRIA NO INCOPORARSE PORQUE ES AUTOINCREMENTAL EN LA PROPIA BD
        public string descripcion;
        public double precioCosto;
        public double precioVenta;
        public int stock;
        public int idUsuario;

        public Producto()
        {
            this.descripcion = string.Empty;
            this.precioCosto = 0;
            this.precioVenta = 0;
            this.stock = 0;
            this.idUsuario = 0;
        }

        public Producto(string descripcion, float precioCosto, float precioVenta, int stock, int idUsuario)
        {
            this.descripcion = descripcion;
            this.precioCosto = precioCosto;
            this.precioVenta = precioVenta;
            this.stock = stock;
            this.idUsuario = idUsuario;
        }

        public Producto(int idProducto, string descripcion, float precioCosto, float precioVenta, int stock, int idUsuario) : this(descripcion, precioCosto, precioVenta, stock, idUsuario)
        {
            this.idProducto = idProducto;
        }

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double PrecioCosto { get => precioCosto; set => precioCosto = value; }
        public double PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Stock { get => stock; set => stock = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }

        public bool CargarProductoDB(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
