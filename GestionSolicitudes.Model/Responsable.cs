using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class Responsable
{
    public int ResponsableId { get; set; }

    public int PersonaNaturalId { get; set; }

    public int AreaId { get; set; }

    public string Correo { get; set; } = null!;

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Area Area { get; set; } = null!;

    public virtual ICollection<Derivado> Derivados { get; set; } = new List<Derivado>();

    public virtual PersonaNatural PersonaNatural { get; set; } = null!;

    public virtual ICollection<Solicitud> SolicitudFrais { get; set; } = new List<Solicitud>();

    public virtual ICollection<Solicitud> SolicitudMpvs { get; set; } = new List<Solicitud>();

    public virtual ICollection<Solicitud> SolicitudResponsableClasificacions { get; set; } = new List<Solicitud>();
}
