namespace TrabajoFinalCoderHouse.Modelos
{
    public class ProductoVendido
    {
        public int idVenta;
        public int idProductoVendido;
        public int idProducto;
        public int stock;

        public ProductoVendido()
        {
            this.idVenta = 0;
            this.idProductoVendido = 0; //PODRIA NO INCOPORARSE PORQUE ES AUTOINCREMENTAL EN LA PROPIA BD
            this.idProducto = 0;
            this.stock = 0;
        }

        public ProductoVendido(int idProducto, int stock, int idVenta)
        {
            this.idVenta = idVenta;
            this.idProducto = idProducto;
            this.stock = stock;
        }

        public ProductoVendido(int idProductoVendido, int idProducto, int stock, int idVenta) : this(idProducto, stock, idVenta)
        {
            this.idProductoVendido = idProductoVendido;
        }

        public int IdVenta { get => idVenta; set => idVenta = value; }
        public int IdProductoVendido { get => idProductoVendido; set => idProductoVendido = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
