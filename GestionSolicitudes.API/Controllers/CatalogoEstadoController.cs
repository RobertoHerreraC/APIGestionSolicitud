using GestionSolicitudes.API.Utilidad;
using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionSolicitudes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoEstadoController : ControllerBase
    {
        private readonly ICatalogoEstadoService _catalogoEstadoServiceServicio;

        public CatalogoEstadoController(ICatalogoEstadoService catalogoEstadoServiceServicio)
        {
            _catalogoEstadoServiceServicio = catalogoEstadoServiceServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<CatalogoEstadoDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _catalogoEstadoServiceServicio.Lista();
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
        public async Task<IActionResult> Guardar([FromBody] CatalogoEstadoDTO catalogoEstado)
        {
            var rsp = new Response<CatalogoEstadoDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _catalogoEstadoServiceServicio.Crear(catalogoEstado);
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
        public async Task<IActionResult> Editar([FromBody] CatalogoEstadoDTO estado)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _catalogoEstadoServiceServicio.Editar(estado);
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
                rsp.value = await _catalogoEstadoServiceServicio.Eliminar(id);
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
