using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class PersonaJuridica
{
    public int PersonaJuridicaId { get; set; }

    public string Ruc { get; set; } = null!;

    public string RazonSocial { get; set; } = null!;

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();
}
