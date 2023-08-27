using AutoMapper;
using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.DAL.Repositorios.Contrato;
using GestionSolicitudes.DTO;
using GestionSolicitudes.Model;
using Microsoft.EntityFrameworkCore;

namespace GestionSolicitudes.BLL.Servicios
{
    public class ResponsableService : IResponsableService
    {
        private readonly IGenericRepository<Responsable> _responsableRepositorio;
        private readonly IMapper _mapper;

        public ResponsableService(IGenericRepository<Responsable> responsableRepositorio, IMapper mapper)
        {
            _responsableRepositorio = responsableRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ResponsableDTO>> BuscarPorId(int id)
        {
            var ListaResultado = new List<Responsable>();
            
            try
            {
                IQueryable<Responsable> query = await _responsableRepositorio.Consultar();
                ListaResultado = await query.Include(resp => resp.PersonaNatural)
                    .Include(resp => resp.Area)
                    .Where(r => r.Estado == true && r.AreaId == id).ToListAsync();

                return _mapper.Map<List<ResponsableDTO>>(ListaResultado);
                
            }
            catch
            {
                throw;
            }
        }
    }
}
