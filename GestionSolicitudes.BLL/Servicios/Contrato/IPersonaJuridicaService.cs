using GestionSolicitudes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.BLL.Servicios.Contrato
{
    public interface IPersonaJuridicaService
    {
        Task<List<PersonaJuridicaDTO>> Lista();
        Task<PersonaJuridicaDTO> Crear(PersonaJuridicaDTO modelo);
        Task<bool> Editar(PersonaJuridicaDTO modelo);
    }
}
