using GestionSolicitudes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.BLL.Servicios.Contrato
{
    public interface IResponsableService
    {
        Task<List<ResponsableDTO>> BuscarPorId(int id);
    }
}
