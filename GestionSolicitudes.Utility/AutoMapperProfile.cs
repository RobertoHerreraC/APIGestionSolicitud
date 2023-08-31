using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AutoMapper;
using GestionSolicitudes.DTO;
using GestionSolicitudes.Model;

namespace GestionSolicitudes.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            #region CatalogoTipoUsuaro
            CreateMap<CatalogoTipoUsuario, CatalogoTipoUsuarioDTO>()
                .ForMember(destino => destino.Activo,
                opt => opt.MapFrom(origen => origen.Estado == true ? 1 : 0));

            CreateMap<CatalogoTipoUsuarioDTO, CatalogoTipoUsuario>()
                .ForMember(destino => destino.Estado,
                opt => opt.MapFrom(origen => origen.Activo == 1 ? true : false));

            #endregion CatalogoTipoUsuaro

            #region CatalogoRol            
            CreateMap<CatalogoRol, CatalogoRolDTO>()
                .ForMember(destino => destino.Activo,
                opt => opt.MapFrom(origen => origen.Estado == true ? 1 : 0));

            CreateMap<CatalogoRolDTO, CatalogoRol>()
                .ForMember(destino => destino.Estado,
                opt => opt.MapFrom(origen => origen.Activo == 1 ? true : false));

            #endregion CatalogoRol

            #region CatalogoEstado
            CreateMap<CatalogoEstado, CatalogoEstadoDTO>()
                .ForMember(destino => destino.Activo,
                opt => opt.MapFrom(origen => origen.Estado == true ? 1 : 0));

            CreateMap<CatalogoEstadoDTO, CatalogoEstado>()
                .ForMember(destino => destino.Estado,
                opt => opt.MapFrom(origen => origen.Activo == 1 ? true : false));

            #endregion CatalogoEstado

            #region CatalogoFormatoEntrega
            CreateMap<CatalogoFormaEntrega, CatalogoFormaEntregaDTO>()
                .ForMember(destino => destino.GeneraCosto,
                opt => opt.MapFrom(origen => origen.GeneraCosto == true ? 1 : 0));

            CreateMap<CatalogoFormaEntregaDTO, CatalogoFormaEntrega>()
                .ForMember(destino => destino.GeneraCosto,
                opt => opt.MapFrom(origen => origen.GeneraCosto  == 1 ? true : false));

            #endregion CatalogoFormatoEntrega

            #region PersonaJuridica

            CreateMap<PersonaJuridica, PersonaJuridicaDTO>()
                .ReverseMap();

            CreateMap<PersonaNatural, PersonaNaturalDTO>()
                .ReverseMap();

            #endregion PersonaJuridica

            #region Tarea
            CreateMap<Tarea, TareaDTO>()
                .ForMember(destino => destino.Activo,
                opt => opt.MapFrom(origen => origen.Estado == true ? 1 : 0))
                .ForMember(destino => destino.DescripcionEstado,
                opt => opt.MapFrom(origen => origen.EstadoNavigation.Descripcion));

            CreateMap<TareaDTO, Tarea>()
                .ForMember(destino => destino.Estado,
                opt => opt.MapFrom(origen => origen.Activo == 1 ? true : false))
                .ForMember(destino => destino.EstadoNavigation,
                opt => opt.Ignore());
            #endregion Tarea

            #region Responsable
            CreateMap<Responsable, ResponsableDTO>()
            .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.PersonaNatural.Nombres))
            .ForMember(dest => dest.ApellidoPaterno, opt => opt.MapFrom(src => src.PersonaNatural.ApellidoPaterno))
            .ForMember(dest => dest.ApellidoMaterno, opt => opt.MapFrom(src => src.PersonaNatural.ApellidoMaterno))
            .ForMember(dest => dest.PersonaNaturalId, opt => opt.MapFrom(src => src.PersonaNaturalId))
            .ForMember(dest => dest.NombreArea, opt => opt.MapFrom(src => src.Area.Nombre));

            #endregion Responsable


            #region Solicitud

            //CreateMap<Solicitud, SolicitudDTO>()
            //.ForMember(dest => dest.FormaEntregaId, opt => opt.MapFrom(src => src.FormaEntregaId.ToString()))
            //.ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.Estado == true ?  1 : 0))
            //.ForMember(dest => dest.BitacoraSolicitud, opt => opt.MapFrom(src => src.Bitacoras));



            CreateMap<Solicitud, SolicitudDTO>()
            .ForMember(dest => dest.FormaEntregaId, opt => opt.MapFrom(src => src.FormaEntregaId.ToString()))
            .ForMember(dest => dest.CostoTotal, opt => opt.MapFrom(src => src.CostoTotal.HasValue ? src.CostoTotal.ToString() : null))
            .ForMember(dest => dest.FechaPresentacion, opt => opt.MapFrom(src => src.FechaPresentacion.HasValue ? src.FechaPresentacion.ToString() : null))
            .ForMember(dest => dest.FechaVencimiento, opt => opt.MapFrom(src => src.FechaVencimiento.HasValue ? src.FechaVencimiento.ToString() : null))
            .ForMember(dest => dest.FechaVencimientoProrroga, opt => opt.MapFrom(src => src.FechaVencimientoProrroga.HasValue ? src.FechaVencimientoProrroga.ToString() : null))
            .ForMember(dest => dest.PlazoMaximo, opt => opt.MapFrom(src => src.PlazoMaximo.ToString()))
            .ForMember(dest => dest.Prorroga, opt => opt.MapFrom(src => src.Prorroga.ToString()))
            .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.Estado == true ? 1 : 0));

            CreateMap<SolicitudDTO, Solicitud>()
            .ForMember(dest => dest.FormaEntregaId, opt => opt.MapFrom(src => int.Parse(src.FormaEntregaId)))
            .ForMember(dest => dest.CostoTotal, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.CostoTotal) ? decimal.Parse(src.CostoTotal) : (decimal?)null))
            .ForMember(dest => dest.FechaPresentacion, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.FechaPresentacion) ? DateTime.Parse(src.FechaPresentacion) : (DateTime?)null))
            .ForMember(dest => dest.FechaVencimiento, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.FechaVencimiento) ? DateTime.Parse(src.FechaVencimiento) : (DateTime?)null))
            .ForMember(dest => dest.FechaVencimientoProrroga, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.FechaVencimientoProrroga) ? DateTime.Parse(src.FechaVencimientoProrroga) : (DateTime?)null))
            .ForMember(dest => dest.PlazoMaximo, opt => opt.MapFrom(src => short.Parse(src.PlazoMaximo)))
            .ForMember(dest => dest.Prorroga, opt => opt.MapFrom(src => short.Parse(src.Prorroga)));



            //CreateMap<SolicitudDTO, Solicitud>()
            //.ForMember(dest => dest.FormaEntregaId, opt => opt.MapFrom(src => int.Parse(src.FormaEntregaId)))
            //.ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Activo == 1 ? true: false))
            //.ForMember(dest => dest.Bitacoras, opt => opt.MapFrom(src => src.BitacoraSolicitud));

            #endregion Solicitud


            /*CreateMap<Solicitud, SolicitudDTO>()
                .ForMember(destino => destino.PersonaNatural,
                opt => opt.MapFrom(origen => origen.PersonaNatural)
                )
                .ForMember(destino => destino.PersonaJuridica,
                opt => opt.MapFrom(origen => origen.PersonaJuridica)
                )
                .ForMember(destino => destino.Activo,
                opt => opt.MapFrom(origen => origen.Estado == true ? 1 : 0)
                )
                .ForMember(destino => destino.TipoInformacion,
                opt => opt.MapFrom(origen => origen.TipoInformacion.Tipo)
                )
                .ForMember(destino => destino.FormaEntrega,
                opt => opt.MapFrom(origen => origen.FormaEntrega.Descripcion)
                )
                .ForMember(destino => destino.MotivoResolucion,
                opt => opt.MapFrom(origen => origen.MotivoResolucion.Motivo)
                );*/
        }
    }
}
