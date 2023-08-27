using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class Feriado
{
    public int FeriadoId { get; set; }

    public short Anio { get; set; }

    public DateTime Fecha { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
