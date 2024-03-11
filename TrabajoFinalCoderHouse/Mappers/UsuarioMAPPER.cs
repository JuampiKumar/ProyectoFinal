using TrabajoFinalCoderHouse.Modelos;
using TrabajoFinalCoderHouse.ModelosDTO;

namespace TrabajoFinalCoderHouse.Mappers
{
    public class UsuarioMAPPER
    {
        public static Usuario MappearAVentas(UsuarioDto dto)
        {
            Usuario usuarios = new Usuario();

            usuarios.Nombre = dto.Nombre;
            usuarios.Apellido = dto.Apellido;
            usuarios.UserName = dto.NombreUsuario;
            usuarios.Mail = dto.Mail;
            return usuarios;
        }

        public static UsuarioDto MappearAVentasDTO(UsuarioDto usuarios)
        {
            UsuarioDto dto = new UsuarioDto();
            dto.Nombre = dto.Nombre;
            dto.Apellido = dto.Apellido;
            dto.NombreUsuario = dto.NombreUsuario;
            dto.Mail = dto.Mail;

            return dto;
        }
    }
}
