using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class Plazo
{
    public int PlazoId { get; set; }

    public short DiasPlazoMaximo { get; set; }

    public short DiasProrroga { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
