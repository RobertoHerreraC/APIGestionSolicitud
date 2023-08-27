using System;
using System.Collections.Generic;
using GestionSolicitudes.Model;
using Microsoft.EntityFrameworkCore;

namespace GestionSolicitudes.DAL.DBContext;

public partial class BdegemsaContext : DbContext
{
    public BdegemsaContext()
    {
    }

    public BdegemsaContext(DbContextOptions<BdegemsaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Bitacora> Bitacoras { get; set; }

    public virtual DbSet<CatalogoEstado> CatalogoEstados { get; set; }

    public virtual DbSet<CatalogoFormaEntrega> CatalogoFormaEntregas { get; set; }

    public virtual DbSet<CatalogoRol> CatalogoRols { get; set; }

    public virtual DbSet<CatalogoTipoDocumento> CatalogoTipoDocumentos { get; set; }

    public virtual DbSet<CatalogoTipoUsuario> CatalogoTipoUsuarios { get; set; }

    public virtual DbSet<Derivado> Derivados { get; set; }

    public virtual DbSet<DocumentoAdjunto> DocumentoAdjuntos { get; set; }

    public virtual DbSet<Feriado> Feriados { get; set; }

    public virtual DbSet<PersonaJuridica> PersonaJuridicas { get; set; }

    public virtual DbSet<PersonaNatural> PersonaNaturals { get; set; }

    public virtual DbSet<Plazo> Plazos { get; set; }

    public virtual DbSet<Responsable> Responsables { get; set; }

    public virtual DbSet<Solicitud> Solicituds { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Area__70B82028289B4249");

            entity.ToTable("Area");

            entity.HasIndex(e => new { e.TipoUsuarioId, e.Nombre }, "uk_tipousuario_nombre").IsUnique();

            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoUsuarioId).HasColumnName("TipoUsuarioID");

            entity.HasOne(d => d.TipoUsuario).WithMany(p => p.Areas)
                .HasForeignKey(d => d.TipoUsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Area__TipoUsuari__02FC7413");
        });

        modelBuilder.Entity<Bitacora>(entity =>
        {
            entity.HasKey(e => e.BitacoraId).HasName("PK__Bitacora__7ACF9B183F1D46C8");

            entity.ToTable("Bitacora");

            entity.Property(e => e.BitacoraId).HasColumnName("BitacoraID");
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaHoraAccion).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SolicitudId).HasColumnName("SolicitudID");
            entity.Property(e => e.TareaId).HasColumnName("TareaID");

            entity.HasOne(d => d.Solicitud).WithMany(p => p.Bitacoras)
                .HasForeignKey(d => d.SolicitudId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bitacora__Solici__208CD6FA");

            entity.HasOne(d => d.Tarea).WithMany(p => p.Bitacoras)
                .HasForeignKey(d => d.TareaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bitacora__TareaI__2180FB33");
        });

        modelBuilder.Entity<CatalogoEstado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Catalogo__FEF86B601098D2EA");

            entity.ToTable("CatalogoEstado");

            entity.HasIndex(e => e.Descripcion, "UQ__Catalogo__92C53B6C4E9A2102").IsUnique();

            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<CatalogoFormaEntrega>(entity =>
        {
            entity.HasKey(e => e.FormaEntregaId).HasName("PK__Catalogo__2B872C2E012381BD");

            entity.ToTable("CatalogoFormaEntrega");

            entity.HasIndex(e => e.Descripcion, "UQ__Catalogo__92C53B6C3C90B399").IsUnique();

            entity.Property(e => e.FormaEntregaId).HasColumnName("FormaEntregaID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GeneraCosto).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<CatalogoRol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Catalogo__F92302D15B090B26");

            entity.ToTable("CatalogoRol");

            entity.HasIndex(e => e.NombreRol, "UQ__Catalogo__4F0B537F27A2906B").IsUnique();

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CatalogoTipoDocumento>(entity =>
        {
            entity.HasKey(e => e.TipoDocumentoId).HasName("PK__Catalogo__A329EAA7487D1A19");

            entity.ToTable("CatalogoTipoDocumento");

            entity.HasIndex(e => e.Descripcion, "UQ__Catalogo__92C53B6C782D6F94").IsUnique();

            entity.Property(e => e.TipoDocumentoId).HasColumnName("TipoDocumentoID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<CatalogoTipoUsuario>(entity =>
        {
            entity.HasKey(e => e.TipoUsuarioId).HasName("PK__Catalogo__7F22C70257078E15");

            entity.ToTable("CatalogoTipoUsuario");

            entity.HasIndex(e => e.Descripcion, "UQ__Catalogo__180325B146E66A58").IsUnique();

            entity.Property(e => e.TipoUsuarioId).HasColumnName("TipoUsuarioID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEscripcion");
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Derivado>(entity =>
        {
            entity.HasKey(e => e.DerivadoId).HasName("PK__Derivado__21AB5F39B52AE678");

            entity.ToTable("Derivado");

            entity.Property(e => e.DerivadoId).HasColumnName("DerivadoID");
            entity.Property(e => e.BitacoraPeticionId).HasColumnName("BitacoraPeticionID");
            entity.Property(e => e.BitacoraRespuestaPeticionId).HasColumnName("BitacoraRespuestaPeticionID");
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ResponsableId).HasColumnName("ResponsableID");

            entity.HasOne(d => d.BitacoraPeticion).WithMany(p => p.DerivadoBitacoraPeticions)
                .HasForeignKey(d => d.BitacoraPeticionId)
                .HasConstraintName("FK__Derivado__Bitaco__2739D489");

            entity.HasOne(d => d.BitacoraRespuestaPeticion).WithMany(p => p.DerivadoBitacoraRespuestaPeticions)
                .HasForeignKey(d => d.BitacoraRespuestaPeticionId)
                .HasConstraintName("FK__Derivado__Bitaco__282DF8C2");

            entity.HasOne(d => d.Responsable).WithMany(p => p.Derivados)
                .HasForeignKey(d => d.ResponsableId)
                .HasConstraintName("FK__Derivado__Respon__2645B050");
        });

        modelBuilder.Entity<DocumentoAdjunto>(entity =>
        {
            entity.HasKey(e => e.DocumentoAdjuntoId).HasName("PK__Document__B24A3B25C91E6535");

            entity.ToTable("DocumentoAdjunto");

            entity.Property(e => e.DocumentoAdjuntoId).HasColumnName("DocumentoAdjuntoID");
            entity.Property(e => e.BitacoraId).HasColumnName("BitacoraID");
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreDocumento)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Ruta)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumentoId).HasColumnName("TipoDocumentoID");

            entity.HasOne(d => d.Bitacora).WithMany(p => p.DocumentoAdjuntos)
                .HasForeignKey(d => d.BitacoraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Documento__Bitac__2CF2ADDF");

            entity.HasOne(d => d.TipoDocumento).WithMany(p => p.DocumentoAdjuntos)
                .HasForeignKey(d => d.TipoDocumentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Documento__TipoD__2DE6D218");
        });

        modelBuilder.Entity<Feriado>(entity =>
        {
            entity.HasKey(e => e.FeriadoId).HasName("PK__Feriado__DBAC383CAB900CA7");

            entity.ToTable("Feriado");

            entity.HasIndex(e => new { e.Anio, e.Fecha, e.Descripcion }, "uk_anio_fecha_descripcion").IsUnique();

            entity.Property(e => e.FeriadoId).HasColumnName("FeriadoID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<PersonaJuridica>(entity =>
        {
            entity.HasKey(e => e.PersonaJuridicaId).HasName("PK__PersonaJ__DB8EC3C50C86D27F");

            entity.ToTable("PersonaJuridica");

            entity.HasIndex(e => e.Ruc, "UQ__PersonaJ__CAF036738436C3A4").IsUnique();

            entity.Property(e => e.PersonaJuridicaId).HasColumnName("PersonaJuridicaID");
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RazonSocial).HasMaxLength(60);
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<PersonaNatural>(entity =>
        {
            entity.HasKey(e => e.PersonaNaturalId).HasName("PK__PersonaN__472DEFFA481DA2B8");

            entity.ToTable("PersonaNatural");

            entity.HasIndex(e => new { e.NroDocumento, e.TipoDocumento }, "uk_nrodoc_tipodoc").IsUnique();

            entity.Property(e => e.PersonaNaturalId).HasColumnName("PersonaNaturalID");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NroDocumento)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(3)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Plazo>(entity =>
        {
            entity.HasKey(e => e.PlazoId).HasName("PK__Plazo__B1FE5AE02FD9A493");

            entity.ToTable("Plazo");

            entity.Property(e => e.PlazoId).HasColumnName("PlazoID");
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Responsable>(entity =>
        {
            entity.HasKey(e => e.ResponsableId).HasName("PK__Responsa__8FC06B85A410BB11");

            entity.ToTable("Responsable");

            entity.HasIndex(e => new { e.PersonaNaturalId, e.AreaId, e.Correo }, "uk_personaid_areaid_correo").IsUnique();

            entity.Property(e => e.ResponsableId).HasColumnName("ResponsableID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.Correo).HasMaxLength(50);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PersonaNaturalId).HasColumnName("PersonaNaturalID");

            entity.HasOne(d => d.Area).WithMany(p => p.Responsables)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Responsab__AreaI__09A971A2");

            entity.HasOne(d => d.PersonaNatural).WithMany(p => p.Responsables)
                .HasForeignKey(d => d.PersonaNaturalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Responsab__Perso__08B54D69");
        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.HasKey(e => e.SolicitudId).HasName("PK__Solicitu__85E95DA726A8700B");

            entity.ToTable("Solicitud");

            entity.Property(e => e.SolicitudId).HasColumnName("SolicitudID");
            entity.Property(e => e.CodigoSigedd)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Correo).HasMaxLength(50);
            entity.Property(e => e.CostoTotal).HasColumnType("smallmoney");
            entity.Property(e => e.Departamento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Distrito)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaPresentacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");
            entity.Property(e => e.FechaVencimientoProrroga).HasColumnType("datetime");
            entity.Property(e => e.FormaEntregaId).HasColumnName("FormaEntregaID");
            entity.Property(e => e.FraiId).HasColumnName("FraiID");
            entity.Property(e => e.MpvId).HasColumnName("MpvID");
            entity.Property(e => e.Observacion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PersonaJuridicaId).HasColumnName("PersonaJuridicaID");
            entity.Property(e => e.PersonaNaturalId).HasColumnName("PersonaNaturalID");
            entity.Property(e => e.Provincia)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ResponsableClasificacionId).HasColumnName("ResponsableClasificacionID");
            entity.Property(e => e.Telefono)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.HasOne(d => d.FormaEntrega).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.FormaEntregaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Solicitud__Forma__18EBB532");

            entity.HasOne(d => d.Frai).WithMany(p => p.SolicitudFrais)
                .HasForeignKey(d => d.FraiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Solicitud__FraiI__160F4887");

            entity.HasOne(d => d.Mpv).WithMany(p => p.SolicitudMpvs)
                .HasForeignKey(d => d.MpvId)
                .HasConstraintName("FK__Solicitud__MpvID__17036CC0");

            entity.HasOne(d => d.PersonaJuridica).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.PersonaJuridicaId)
                .HasConstraintName("FK__Solicitud__Perso__14270015");

            entity.HasOne(d => d.PersonaNatural).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.PersonaNaturalId)
                .HasConstraintName("FK__Solicitud__Perso__151B244E");

            entity.HasOne(d => d.ResponsableClasificacion).WithMany(p => p.SolicitudResponsableClasificacions)
                .HasForeignKey(d => d.ResponsableClasificacionId)
                .HasConstraintName("FK__Solicitud__Respo__17F790F9");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.TareaId).HasName("PK__Tarea__5CD83671C07DF503");

            entity.ToTable("Tarea");

            entity.Property(e => e.TareaId).HasColumnName("TareaID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Tarea__EstadoID__7D439ABD");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE798897F249D");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A19B399E5E1").IsUnique();

            entity.HasIndex(e => e.Pass, "UQ__Usuario__A15FAEB11734C850").IsUnique();

            entity.HasIndex(e => e.Usuario1, "UQ__Usuario__E3237CF7BD821331").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Correo).HasMaxLength(50);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Pass).HasMaxLength(200);
            entity.Property(e => e.PersonaId).HasColumnName("PersonaID");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Usuario");

            entity.HasOne(d => d.Persona).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PersonaId)
                .HasConstraintName("FK__Usuario__Persona__787EE5A0");
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.UsuarioRolId).HasName("PK__UsuarioR__C869CD2AA1FDFF96");

            entity.ToTable("UsuarioRol");

            entity.Property(e => e.UsuarioRolId).HasColumnName("UsuarioRolID");
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioRo__RolID__0E6E26BF");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioRo__Usuar__0F624AF8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
