using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class DocumentoAdjunto
{
    public int DocumentoAdjuntoId { get; set; }

    public int BitacoraId { get; set; }

    public int TipoDocumentoId { get; set; }

    public string NombreDocumento { get; set; } = null!;

    public string Ruta { get; set; } = null!;

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Bitacora Bitacora { get; set; } = null!;

    public virtual CatalogoTipoDocumento TipoDocumento { get; set; } = null!;
}
