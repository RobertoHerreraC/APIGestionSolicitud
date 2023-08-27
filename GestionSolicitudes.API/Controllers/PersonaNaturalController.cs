using GestionSolicitudes.API.Utilidad;
using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestionSolicitudes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaNaturalController : Controller
    {

        private readonly IPersonaNaturalService _personaNatutalServiceServicio;

        public PersonaNaturalController(IPersonaNaturalService personaNatutalServiceServicio)
        {
            _personaNatutalServiceServicio = personaNatutalServiceServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<PersonaNaturalDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _personaNatutalServiceServicio.Lista();
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
        public async Task<IActionResult> Guardar([FromBody] PersonaNaturalDTO catalogoRol)
        {
            var rsp = new Response<PersonaNaturalDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _personaNatutalServiceServicio.Crear(catalogoRol);
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
        public async Task<IActionResult> Editar([FromBody] PersonaNaturalDTO persona)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _personaNatutalServiceServicio.Editar(persona);
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
