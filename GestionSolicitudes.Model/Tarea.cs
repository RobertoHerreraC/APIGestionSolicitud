using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class Tarea
{
    public int TareaId { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? EstadoId { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Bitacora> Bitacoras { get; set; } = new List<Bitacora>();

    public virtual CatalogoEstado? EstadoNavigation { get; set; }
}
