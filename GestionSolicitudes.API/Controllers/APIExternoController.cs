using GestionSolicitudes.API.Utilidad;
using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.DTO;
using GestionSolicitudes.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace GestionSolicitudes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIExternoController : Controller
    {
        private readonly IAPIService _apiServiceServicio;

        public APIExternoController(IAPIService apiServiceServicio)
        {
            _apiServiceServicio = apiServiceServicio;
        }

        [HttpGet]
        [Route("{nroDocumento}")]
        public async Task<IActionResult> validarDNI(string nroDocumento)
        {
            var rsp = new Response<PersonaAPI>();
            try
            {
                rsp.status = true;
                rsp.value =  await _apiServiceServicio.validarDni(nroDocumento);
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
