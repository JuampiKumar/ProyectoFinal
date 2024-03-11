namespace TrabajoFinalCoderHouse.Modelos
{
    public class Usuario
    {
        public int idUser; //PODRIA NO INCOPORARSE PORQUE ES AUTOINCREMENTAL EN LA PROPIA BD
        public string nombre;
        public string apellido;
        public string userName;
        public string userPass;
        public string mail;

        public Usuario()
        {
            this.idUser = 0;
            this.nombre = string.Empty;
            this.apellido = string.Empty;
            this.userName = string.Empty;
            this.userPass = string.Empty;
            this.mail = string.Empty;
        }

        public Usuario(string nombre, string apellido, string userName, string userPass, string mail)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.userName = userName;
            this.userPass = userPass;
            this.mail = mail;
        }

        public Usuario(int id, string nombre, string apellido, string userName, string userPass, string mail) : this(nombre, apellido, userName, userPass, mail)
        {
            this.idUser = id;
        }

        public int IdUser { get => idUser; set => idUser = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserPass { get => userPass; set => userPass = value; }
        public string Mail { get => mail; set => mail = value; }
    }
}
