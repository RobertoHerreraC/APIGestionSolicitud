using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class CatalogoEstado
{
    public int EstadoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
