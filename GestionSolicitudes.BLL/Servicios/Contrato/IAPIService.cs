using GestionSolicitudes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.BLL.Servicios.Contrato
{
    public interface IAPIService
    {
        Task<PersonaAPI> validarDni(string numDocumento);
    }
}
