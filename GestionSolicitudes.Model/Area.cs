using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class Area
{
    public int AreaId { get; set; }

    public int TipoUsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Responsable> Responsables { get; set; } = new List<Responsable>();

    public virtual CatalogoTipoUsuario TipoUsuario { get; set; } = null!;
}
