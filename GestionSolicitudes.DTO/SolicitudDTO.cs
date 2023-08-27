using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DTO
{
    public class SolicitudDTO
    {
        public int? SolicitudId { get; set; }
        public PersonaJuridicaDTO? PersonaJuridica { get; set; }
        public PersonaNaturalDTO? PersonaNatural { get; set; }
        /*public string? TipoPersona { get; set; } = "";*/
        public string? MotivoResolucion { get; set; }
        public string? TipoInformacion { get; set; } = "";
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
        public int? Activo { get; set; }
        public string? PlazoMaximo { get; set; }
        public string? Prorroga { get; set; }
        public string? Observacion { get; set; }
        public List<SolicitudDetallesDTO>? BitacoraSolicitud { get; set; }

    }
}
