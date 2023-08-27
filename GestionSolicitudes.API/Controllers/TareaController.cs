using GestionSolicitudes.API.Utilidad;
using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestionSolicitudes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : Controller
    {
        private readonly ITareaService _tareaServiceServicio;

        public TareaController(ITareaService tareaServiceServicio)
        {
            _tareaServiceServicio = tareaServiceServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<TareaDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _tareaServiceServicio.Lista();
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
        public async Task<IActionResult> Guardar([FromBody] TareaDTO tarea)
        {
            var rsp = new Response<TareaDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _tareaServiceServicio.Crear(tarea);
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
