using GestionSolicitudes.API.Utilidad;
using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestionSolicitudes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : Controller
    {
        private readonly ISolicitudService _solicitudServiceServicio;

        public SolicitudController(ISolicitudService solicitudServiceServicio)
        {
            _solicitudServiceServicio = solicitudServiceServicio;
        }

        [HttpPost]
        [Route("Alta")]
        public async Task<IActionResult> Alta([FromBody] SolicitudDTO solicitud)
        {
            var rsp = new Response<SolicitudDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _solicitudServiceServicio.Crear(solicitud);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.ToString();
            }

            return Ok(rsp);
        }

    }
}
