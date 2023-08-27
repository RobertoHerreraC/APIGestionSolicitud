using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DTO
{
    public class ReporteSolicitudDTO
    {
        public string? SolicitudId { get; set; }
        public string? PersonaJuridicaNatural { get; set; }
        public string? NroDocumentoIdentidad { get; set; }
        public string? TipoDocumentoIdentidad { get; set; }
        public string? InformacionSolicitada { get; set; } = "";
        public string? FormaEntrega { get; set; } = "";
        public string? Direccion { get; set; } = null!;
        public string? Departamento { get; set; } = null!;
        public string? Provincia { get; set; } = null!;
        public string? Distrito { get; set; } = null!;
        public string? CodigoSigedd { get; set; }
        public string? CostoTotal { get; set; }
        public string? FechaPresentacion { get; set; }
        public string? FechaVencimiento { get; set; }
        public string? FechaVencimientoProrroga { get; set; }
        public string? Estado { get; set; }
    }
}
