using GestionSolicitudes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.BLL.Servicios.Contrato
{
    public interface IPersonaNaturalService
    {
        Task<List<PersonaNaturalDTO>> Lista();
        Task<PersonaNaturalDTO> Crear(PersonaNaturalDTO modelo);
        Task<bool> Editar(PersonaNaturalDTO modelo);
    }
}
