using System;
using System.Collections.Generic;

namespace GestionSolicitudes.Model;

public partial class Solicitud
{
    public int SolicitudId { get; set; }

    public int? PersonaJuridicaId { get; set; }

    public int? PersonaNaturalId { get; set; }

    public int FraiId { get; set; }

    public int? MpvId { get; set; }

    public int? ResponsableClasificacionId { get; set; }

    public string Correo { get; set; } = null!;

    public string? Telefono { get; set; }

    public string InformacionSolicitada { get; set; } = null!;

    public int FormaEntregaId { get; set; }

    public string Direccion { get; set; } = null!;

    public string Departamento { get; set; } = null!;

    public string Provincia { get; set; } = null!;

    public string Distrito { get; set; } = null!;

    public string? CodigoSigedd { get; set; }

    public decimal? CostoTotal { get; set; }

    public DateTime? FechaPresentacion { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public DateTime? FechaVencimientoProrroga { get; set; }

    public short PlazoMaximo { get; set; }

    public short Prorroga { get; set; }

    public string? Observacion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Bitacora> Bitacoras { get; set; } = new List<Bitacora>();

    public virtual CatalogoFormaEntrega FormaEntrega { get; set; } = null!;

    public virtual Responsable Frai { get; set; } = null!;

    public virtual Responsable? Mpv { get; set; }

    public virtual PersonaJuridica? PersonaJuridica { get; set; }

    public virtual PersonaNatural? PersonaNatural { get; set; }

    public virtual Responsable? ResponsableClasificacion { get; set; }
}
