using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class CatalogoRol
{
    public int RolId { get; set; }

    public string NombreRol { get; set; } = null!;

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
