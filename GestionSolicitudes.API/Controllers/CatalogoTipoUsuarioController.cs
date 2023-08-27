using GestionSolicitudes.API.BLL.Servicio.Contrato;
using GestionSolicitudes.API.Utilidad;
using GestionSolicitudes.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestionSolicitudes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoTipoUsuarioController : Controller
    {
        private readonly ICatalogoTipoUsuarioService _catalogoTipoUsuarioServiceServicio;

        public CatalogoTipoUsuarioController(ICatalogoTipoUsuarioService catalogoTipoUsuarioServiceServicio)
        {
            _catalogoTipoUsuarioServiceServicio = catalogoTipoUsuarioServiceServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<CatalogoTipoUsuarioDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _catalogoTipoUsuarioServiceServicio.Lista();
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] CatalogoTipoUsuarioDTO catalogoTipoUsuario)
        {
            var rsp = new Response<CatalogoTipoUsuarioDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _catalogoTipoUsuarioServiceServicio.Crear(catalogoTipoUsuario);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] CatalogoTipoUsuarioDTO usuario)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _catalogoTipoUsuarioServiceServicio.Editar(usuario);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPut]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _catalogoTipoUsuarioServiceServicio.Eliminar(id);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }

    }
}
