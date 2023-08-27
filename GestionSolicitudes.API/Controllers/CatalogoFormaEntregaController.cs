using GestionSolicitudes.API.Utilidad;
using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestionSolicitudes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoFormaEntregaController : Controller
    {
        private readonly ICatalogoFormaEntregaService _catalogoFormaEntregaServiceServicio;

        public CatalogoFormaEntregaController(ICatalogoFormaEntregaService catalogoFormaEntregaServiceServicio)
        {
            _catalogoFormaEntregaServiceServicio = catalogoFormaEntregaServiceServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<CatalogoFormaEntregaDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _catalogoFormaEntregaServiceServicio.Lista();
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
        public async Task<IActionResult> Guardar([FromBody] CatalogoFormaEntregaDTO catalogoFormaEntrega)
        {
            var rsp = new Response<CatalogoFormaEntregaDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _catalogoFormaEntregaServiceServicio.Crear(catalogoFormaEntrega);
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
        public async Task<IActionResult> Editar([FromBody] CatalogoFormaEntregaDTO estado)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _catalogoFormaEntregaServiceServicio.Editar(estado);
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
                rsp.value = await _catalogoFormaEntregaServiceServicio.Eliminar(id);
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
