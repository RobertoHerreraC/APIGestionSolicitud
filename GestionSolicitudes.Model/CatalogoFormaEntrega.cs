using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class CatalogoFormaEntrega
{
    public int FormaEntregaId { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool? GeneraCosto { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();
}
