using Microsoft.AspNetCore.Mvc;
using TrabajoFinalCoderHouse.Database;
using TrabajoFinalCoderHouse.Modelos;
using TrabajoFinalCoderHouse.ModelosDTO;
using TrabajoFinalCoderHouse.Services;

namespace TrabajoFinalCoderHouse.Controladores
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioControlador
    {
        private readonly coderhouse context;
        private readonly UsuarioServices _usuarioService;

        public UsuarioControlador(coderhouse coderHouse, UsuarioServices usuarioService)
        {
            this.context = coderHouse;
            this._usuarioService = usuarioService;
        }

        [HttpGet]
        public List<Usuario> ObtenerListadoDeUsuarios()
        {
            return _usuarioService.ObtenerTodosLosUsuarios();
        }

        [HttpGet("{nombreUsuario}")]
        public ActionResult<Usuario> GetUsuarioPorNombreUsuario(string nombreUsuario)
        {
            var usuario = UsuarioServices.ObtenerUsuarioPorNombreUsuario(nombreUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }


        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario(int id, UsuarioDto usuarioDTO)
        {
            if (id != usuarioDTO.Id)
            {
                return BadRequest();
            }

            var usuario = new Usuario
            {
                Id = usuarioDTO.Id,
                Nombre = usuarioDTO.Nombre,
                NombreUsuario = usuarioDTO.NombreUsuario,
                Apellido = usuarioDTO.Apellido,
                Mail = usuarioDTO.Mail
            };

            var usuarioActualizado = UsuarioService.ActualizarUsuario(usuario);
            if (usuarioActualizado == null)
            {
                return NotFound();
            }
            return Ok(usuarioActualizado);
        }
    }
}
