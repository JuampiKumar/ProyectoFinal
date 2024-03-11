namespace TrabajoFinalCoderHouse.Modelos
{
    public class Venta
    {
        public int idVenta; //PODRIA NO INCOPORARSE PORQUE ES AUTOINCREMENTAL EN LA PROPIA BD
        public string comentarioVenta;
        public int idUsuario;

        public Venta()
        {
            this.idVenta = 0;
            this.comentarioVenta = string.Empty;
            this.idUsuario = 0;
        }

        public Venta(string comentarioVenta, int idUsuario)
        {
            this.comentarioVenta = comentarioVenta;
            this.idUsuario = idUsuario;
        }

        public Venta(int idVenta, string comentarioVenta, int idUsuario) : this(comentarioVenta, idUsuario)
        {
            this.idVenta = idVenta;
        }

        public int IdVenta { get => idVenta; set => idVenta = value; }
        public string ComentarioVenta { get => comentarioVenta; set => comentarioVenta = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}
