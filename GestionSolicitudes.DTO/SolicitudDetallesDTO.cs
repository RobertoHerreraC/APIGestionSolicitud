using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DTO
{
    public class SolicitudDetallesDTO
    {
        public int BitacoraId { get; set; }
        public string? DescripcionTarea { get; set; }
        public string? EstadoTarea { get; set; }
        public string? FechaHoraAccion { get; set; }

    }
}
