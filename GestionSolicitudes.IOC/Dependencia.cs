using GestionSolicitudes.DAL.Repositorios.Contrato;
using GestionSolicitudes.DAL.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionSolicitudes.Utility;

using GestionSolicitudes.API.BLL.Servicio.Contrato;
using GestionSolicitudes.API.BLL.Servicio;
using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.BLL.Servicios;
using GestionSolicitudes.DAL.DBContext;

namespace GestionSolicitudes.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<BdegemsaContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQLString"));
            });

            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            service.AddScoped<ISolicitudRepository, SolicitudRepository>();

            service.AddAutoMapper(typeof(AutoMapperProfile));

            service.AddScoped<ICatalogoTipoUsuarioService, CatalogoTipoUsuarioService>();
            service.AddScoped<ICatalogoRolService, CatalogoRolService>();
            service.AddScoped<ICatalogoEstadoService, CatalogoEstadoService>();
            service.AddScoped<ICatalogoFormaEntregaService, CatalogoFormaEntregaService>();
            service.AddScoped<IPersonaJuridicaService, PersonaJuridicaService>();
            service.AddScoped<IPersonaNaturalService, PersonaNaturalService>();
            service.AddScoped<ITareaService, TareaService>();
            service.AddScoped<IResponsableService, ResponsableService>();
        }
    }
}
