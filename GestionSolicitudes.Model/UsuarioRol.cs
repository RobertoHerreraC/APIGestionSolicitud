using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class UsuarioRol
{
    public int UsuarioRolId { get; set; }

    public int RolId { get; set; }

    public int UsuarioId { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual CatalogoRol Rol { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
