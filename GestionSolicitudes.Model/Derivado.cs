using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class Derivado
{
    public int DerivadoId { get; set; }

    public int? ResponsableId { get; set; }

    public int? BitacoraPeticionId { get; set; }

    public int? BitacoraRespuestaPeticionId { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Bitacora? BitacoraPeticion { get; set; }

    public virtual Bitacora? BitacoraRespuestaPeticion { get; set; }

    public virtual Responsable? Responsable { get; set; }
}
