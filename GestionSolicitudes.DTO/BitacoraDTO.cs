using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DTO
{
    public class BitacoraDTO
    {
        public int BitacoraId { get; set; }
        public int SolicitudId { get; set; }
        public int TareaId { get; set; }
        public string? DescripcionTarea { get; set; } = null!;
        public string? EstadoTarea { get; set; }
        public string? FechaHoraAccion { get; set; }
        public string? Comentario { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public List<AdjuntoDTO>? Adjuntos { get; set; }
        public List<DerivadoBitacoraDTO>? Derivados { get; set; }
    }
}
