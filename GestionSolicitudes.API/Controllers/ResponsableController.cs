using GestionSolicitudes.API.Utilidad;
using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestionSolicitudes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsableController : Controller
    {
        private readonly IResponsableService _responsableServiceServicio;

        public ResponsableController(IResponsableService responsableServiceServicio)
        {
            _responsableServiceServicio = responsableServiceServicio;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObtenerResponsablePorArea(int id)
        {
            var rsp = new Response<List<ResponsableDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _responsableServiceServicio.BuscarPorId(id);

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
