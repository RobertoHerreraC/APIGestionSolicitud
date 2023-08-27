using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int? PersonaId { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual PersonaNatural? Persona { get; set; }

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
