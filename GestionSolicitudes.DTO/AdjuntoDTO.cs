using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DTO
{
    public class AdjuntoDTO
    {
        public int DocumentoAdjuntoId { get; set; }
        public string? TipoDocumento { get; set; } = "";
        public string NombreDocumento { get; set; } = "";
        public string Ruta { get; set; } = "";
        public string? FechaRegistro { get; set; }
    }
}
