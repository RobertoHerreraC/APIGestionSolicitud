using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class PersonaNatural
{
    public int PersonaNaturalId { get; set; }

    public string Nombres { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public string NroDocumento { get; set; } = null!;

    public string TipoDocumento { get; set; } = null!;

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Responsable> Responsables { get; set; } = new List<Responsable>();

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
