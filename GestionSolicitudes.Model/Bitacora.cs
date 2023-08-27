using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class Bitacora
{
    public int BitacoraId { get; set; }

    public int SolicitudId { get; set; }

    public int TareaId { get; set; }

    public DateTime FechaHoraAccion { get; set; }

    public string? Comentario { get; set; }

    public string? Observacion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Derivado> DerivadoBitacoraPeticions { get; set; } = new List<Derivado>();

    public virtual ICollection<Derivado> DerivadoBitacoraRespuestaPeticions { get; set; } = new List<Derivado>();

    public virtual ICollection<DocumentoAdjunto> DocumentoAdjuntos { get; set; } = new List<DocumentoAdjunto>();

    public virtual Solicitud Solicitud { get; set; } = null!;

    public virtual Tarea Tarea { get; set; } = null!;
}
