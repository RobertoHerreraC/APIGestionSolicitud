using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class CatalogoTipoDocumento
{
    public int TipoDocumentoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DocumentoAdjunto> DocumentoAdjuntos { get; set; } = new List<DocumentoAdjunto>();
}
