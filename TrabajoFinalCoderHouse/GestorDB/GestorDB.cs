using Microsoft.Data.SqlClient;
using TrabajoFinalCoderHouse.Modelos;

namespace TrabajoFinalCoderHouse.GestorDB
{
    public class GestorDB
    {
        private string stringConnection;
        public GestorDB()
        {
            this.stringConnection = "Server=LAPTOP-KC4DJ9JO;Database=coderhouse;Trusted_Connection=True;";
        }

        public Producto ObtenerProductoPorID(int id)

        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM Producto WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["ID"]);
                    string detalleObtenido = reader.GetString(1);
                    float costoObtenido = Convert.ToInt32(reader["Costo"]);
                    float precioVentaObtenido = Convert.ToInt32(reader["PrecioVenta"]);
                    int stockObtenido = Convert.ToInt32(reader["Stock"]);
                    int idUsuarioObtenido = Convert.ToInt32(reader["IdUsuario"]);

                    Producto producto = new Producto(idObtenido, detalleObtenido, costoObtenido, precioVentaObtenido, stockObtenido, idUsuarioObtenido);

                    return producto;
                }

                throw new Exception("ID NO ENCONTRADO");
            }
        }

        public List<Producto> ListaDeProductosDesdeDB()
        {
            List<Producto> listaProductos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT Id, Descricpiones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.idProducto = Convert.ToInt32(reader["Id"]);
                        producto.descripcion = reader["Descripciones"].ToString();
                        producto.precioCosto = Convert.ToDouble(reader["Costo"]);
                        producto.precioVenta = Convert.ToDouble(reader["precioVenta"]);
                        producto.stock = Convert.ToInt32(reader["Stock"]);
                        producto.idUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        listaProductos.Add(producto);
                    }
                }
            }
            return listaProductos;
        }

        public bool CargarProductoDB(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@descripcion, @costo, @precioVenta, @stock, @idUsuario);";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("costo", producto.PrecioCosto);
                cmd.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("stock", producto.Stock);
                cmd.Parameters.AddWithValue("idUsuario", producto.IdUsuario);
                connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool BorrarProductoDB(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "DELETE * FROM Producto WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ModificarProductoDB(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "UPDATE Usuario SET Descripciones = @descripcion, Cost = @precioCosto, PrecioVenta = @precioVenta, Stock = @stock, idUsuario = @idUsuario WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("precioCosto", producto.PrecioCosto);
                cmd.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("stock", producto.Stock);
                cmd.Parameters.AddWithValue("idUsuario", producto.IdUsuario);
                connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public ProductoVendido ObtenerProductoVendidoPorID(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM ProductoVendido WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["ID"]);
                    int stockObtenido = Convert.ToInt32(reader["Stock"]);
                    int idProductoObtenido = Convert.ToInt32(reader["IdProducto"]);
                    int idVentaObtenido = Convert.ToInt32(reader["IdVenta"]);

                    ProductoVendido productoVendido = new ProductoVendido(idObtenido, stockObtenido, idProductoObtenido, idVentaObtenido);

                    return productoVendido;
                }

                throw new Exception("ID NO ENCONTRADO");
            }
        }

        public List<ProductoVendido> ListaDeProductosVendidosDesdeDB()
        {
            List<ProductoVendido> listaProductosVendidos = new List<ProductoVendido>();

            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductoVendido productoVendido = new ProductoVendido();
                        productoVendido.idProductoVendido = Convert.ToInt32(reader["Id"]);
                        productoVendido.stock = Convert.ToInt32(reader["Stock"]);
                        productoVendido.idProducto = Convert.ToInt32(reader["IdProducto"]);
                        productoVendido.idVenta = Convert.ToInt32(reader["IdVenta"]);
                        listaProductosVendidos.Add(productoVendido);
                    }
                }
            }
            return listaProductosVendidos;
        }

        public bool cargarProductoVendidoDB(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "INSERT INTO Venta (Comentarios, IdUsuario) VALUES (@comentario, @idUsuario);";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("comentario", venta.ComentarioVenta);
                cmd.Parameters.AddWithValue("idUsuario", venta.IdUsuario);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool borrarProductoVendidoDB(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "DELETE * FROM Venta WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool modificarProductoVendidoDB(int id, Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "UPDATE Venta SET Comentarios = @comentario, idUsuario = @idUsuario WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("comentario", venta.ComentarioVenta);
                cmd.Parameters.AddWithValue("idUsuario", venta.IdUsuario);
                connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Usuario obtenerUsuarioPorID(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM Usuario WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["ID"]);
                    string nombreObtenido = reader.GetString(1);
                    string apellidoObtenido = reader.GetString(2);
                    string userNameObtenido = reader.GetString(3);
                    string passwordObtenido = reader.GetString(4);
                    string emailObtenido = reader.GetString(5);

                    Usuario usuario = new Usuario(idObtenido, nombreObtenido, apellidoObtenido, emailObtenido, passwordObtenido, emailObtenido);

                    return usuario;
                }

                throw new Exception("ID NO ENCONTRADO");
            }
        }

        public List<Usuario> ListaDeUsuariosDesdeDB()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.idUser = Convert.ToInt32(reader["Id"]);
                        usuario.nombre = reader["Nombre"].ToString();
                        usuario.apellido = reader["Apellido"].ToString();
                        usuario.userName = reader["NombreUsuario"].ToString();
                        usuario.userPass = reader["Contraseña"].ToString();
                        usuario.mail = reader["Mail"].ToString();
                        listaUsuarios.Add(usuario);
                    }
                }
            }
            return listaUsuarios;
        }

        public bool cargarUsuarioDB(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES (@nombre, @apellido, @nombreUsuario, @password, @mail);";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("nombreUsuario", usuario.UserName);
                cmd.Parameters.AddWithValue("password", usuario.UserPass);
                cmd.Parameters.AddWithValue("mail", usuario.Mail);

                connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool borrarUsuarioDB(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "DELETE * FROM Usuario WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool modificarUsuarioDB(int id, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "UPDATE Usuario SET Nombre = @nombre, Apellido = @apellido, NombreUsuario = @userName, Contraseña = @password, Mail = @mail WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("nombreUsuario", usuario.UserName);
                cmd.Parameters.AddWithValue("password", usuario.UserPass);
                cmd.Parameters.AddWithValue("mail", usuario.Mail);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Venta ObtenerVentaPorID(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM Venta WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["ID"]);
                    string comentarioObtenido = reader.GetString(1);
                    int idUsuarioObtenido = Convert.ToInt32(reader["IdUsuario"]);

                    Venta venta = new Venta(idObtenido, comentarioObtenido, idUsuarioObtenido);

                    return venta;
                }

                throw new Exception("ID NO ENCONTRADO");
            }
        }

        public List<Venta> ListaDeVentasDesdeDB()
        {
            List<Venta> listaVentas = new List<Venta>();

            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT Id, Comentarios, IdUsuario FROM Venta";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta venta = new Venta();
                        venta.idVenta = Convert.ToInt32(reader["Id"]);
                        venta.comentarioVenta = reader["Comentarios"].ToString();
                        venta.idUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        listaVentas.Add(venta);
                    }
                }
            }
            return listaVentas;
        }

        public bool CargarVentaDB(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "INSERT INTO Venta (Comentarios, IdUsuario) VALUES (@comentario, @idUsuario);";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("comentario", venta.ComentarioVenta);
                cmd.Parameters.AddWithValue("idUsuario", venta.IdUsuario);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool BorrarVentaDB(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "DELETE * FROM Venta WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ModificarVentaDB(int id, Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "UPDATE Venta SET Comentarios = @comentario, idUsuario = @idUsuario WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("comentario", venta.ComentarioVenta);
                cmd.Parameters.AddWithValue("idUsuario", venta.IdUsuario);
                connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
