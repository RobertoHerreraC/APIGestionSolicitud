using GestionSolicitudes.DAL.Repositorios.Contrato;
using GestionSolicitudes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DAL.Repositorios
{
    public interface ISolicitudRepository : IGenericRepository<Solicitud>
    {
        Task<Solicitud> Registrar(Solicitud solicitud);
    }
}
