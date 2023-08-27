using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class CatalogoTipoUsuario
{
    public int TipoUsuarioId { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();
}
