using AutoMapper;
using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.DAL.Repositorios.Contrato;
using GestionSolicitudes.DTO;
using GestionSolicitudes.Model;

namespace GestionSolicitudes.BLL.Servicios
{
    public class SolicitudService : ISolicitudService
    {
        private readonly ISolicitudRepository _solicitudRepositorio;
        private readonly IMapper _mapper;

        public SolicitudService(ISolicitudRepository solicitudRepositorio, IMapper mapper)
        {
            _solicitudRepositorio = solicitudRepositorio;
            _mapper = mapper;
        }

        public async Task<SolicitudDTO> Crear(SolicitudDTO modelo)
        {
            try
            {
                var solicitudCreado = await _solicitudRepositorio.Alta(_mapper.Map<Solicitud>(modelo));

                if (solicitudCreado.SolicitudId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _solicitudRepositorio.Consultar(u => u.SolicitudId == solicitudCreado.SolicitudId);
                solicitudCreado = query.FirstOrDefault();

                return _mapper.Map<SolicitudDTO>(solicitudCreado);
            }
            catch
            {
                throw;
            }
        }
    }
}
