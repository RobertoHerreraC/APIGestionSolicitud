using GestionSolicitudes.API.Utilidad;
using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestionSolicitudes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaJuridicaController : Controller
    {
        private readonly IPersonaJuridicaService _personaJuridicaServiceServicio;

        public PersonaJuridicaController(IPersonaJuridicaService personaJuridicaServiceServicio)
        {
            _personaJuridicaServiceServicio = personaJuridicaServiceServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<PersonaJuridicaDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _personaJuridicaServiceServicio.Lista();
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
        public async Task<IActionResult> Guardar([FromBody] PersonaJuridicaDTO personaJuridica)
        {
            var rsp = new Response<PersonaJuridicaDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _personaJuridicaServiceServicio.Crear(personaJuridica);
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
        public async Task<IActionResult> Editar([FromBody] PersonaJuridicaDTO personaJuridica)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _personaJuridicaServiceServicio.Editar(personaJuridica);
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
