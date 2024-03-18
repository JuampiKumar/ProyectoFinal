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
                return NotFoundResult();
            }
            return OkObjectResult(usuario);
        }

        private ActionResult<Usuario> NotFoundResult()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario(int id, UsuarioDto usuarioDTO)
        {
            if (id != usuarioDTO.Id)
            {
                return BadRequestResult();
            }

            var usuario = new Usuario
            {
                idUser = usuarioDTO.Id,
                Nombre = usuarioDTO.Nombre,
                userName = usuarioDTO.NombreUsuario,
                Apellido = usuarioDTO.Apellido,
                Mail = usuarioDTO.Mail
            };

            var usuarioActualizado = UsuarioServices.ActualizarUsuario(usuario);
            if (usuarioActualizado == null)
            {
                return NotFoundResult();
            }
            return OkObjectResult(usuarioActualizado);
        }

        private IActionResult OkObjectResult(bool usuarioActualizado)
        {
            throw new NotImplementedException();
        }

        private IActionResult BadRequestResult()
        {
            throw new NotImplementedException();
        }
    }
}
