using GestionSolicitudes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.BLL.Servicios.Contrato
{
    public interface ISolicitudService
    {
        Task<SolicitudDTO> Crear(SolicitudDTO modelo);
    }
}
