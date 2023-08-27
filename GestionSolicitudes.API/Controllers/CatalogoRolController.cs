using GestionSolicitudes.API.BLL.Servicio.Contrato;
using GestionSolicitudes.API.Utilidad;
using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestionSolicitudes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoRolController : Controller
    {
        private readonly ICatalogoRolService _catalogoRolServiceServicio;

        public CatalogoRolController(ICatalogoRolService catalogoRolServiceServicio)
        {
            _catalogoRolServiceServicio = catalogoRolServiceServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<CatalogoRolDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _catalogoRolServiceServicio.Lista();
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
        public async Task<IActionResult> Guardar([FromBody] CatalogoRolDTO catalogoRol)
        {
            var rsp = new Response<CatalogoRolDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _catalogoRolServiceServicio.Crear(catalogoRol);
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
        public async Task<IActionResult> Editar([FromBody] CatalogoRolDTO rol)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _catalogoRolServiceServicio.Editar(rol);
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
                rsp.value = await _catalogoRolServiceServicio.Eliminar(id);
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
