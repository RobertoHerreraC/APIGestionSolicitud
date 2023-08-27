using AutoMapper;
using GestionSolicitudes.API.BLL.Servicio.Contrato;
using GestionSolicitudes.DAL.Repositorios.Contrato;
using GestionSolicitudes.DTO;
using GestionSolicitudes.Model;

namespace GestionSolicitudes.API.BLL.Servicio
{
    public class CatalogoTipoUsuarioService : ICatalogoTipoUsuarioService
    {
        private readonly IGenericRepository<CatalogoTipoUsuario> _catalogoTipoUsuarioRepositorio;
        private readonly IMapper _mapper;

        public CatalogoTipoUsuarioService(IGenericRepository<CatalogoTipoUsuario> catalogoTipoUsuarioRepositorio, IMapper mapper)
        {
            _catalogoTipoUsuarioRepositorio = catalogoTipoUsuarioRepositorio;
            _mapper = mapper;
        }

        public async Task<CatalogoTipoUsuarioDTO> Crear(CatalogoTipoUsuarioDTO modelo)
        {
            try
            {
                var tipoUsuarioCreado = await _catalogoTipoUsuarioRepositorio.Crear(_mapper.Map<CatalogoTipoUsuario>(modelo));

                if (tipoUsuarioCreado.TipoUsuarioId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _catalogoTipoUsuarioRepositorio.Consultar(u => u.TipoUsuarioId == tipoUsuarioCreado.TipoUsuarioId);
                tipoUsuarioCreado = query.First();

                return _mapper.Map<CatalogoTipoUsuarioDTO>(tipoUsuarioCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(CatalogoTipoUsuarioDTO modelo)
        {
            try
            {
                var tipoUsuarioModelo = _mapper.Map<CatalogoTipoUsuario>(modelo);
                var tipoUsuarioEncontrado = await _catalogoTipoUsuarioRepositorio.Obtener(u => u.TipoUsuarioId == tipoUsuarioModelo.TipoUsuarioId);

                if (tipoUsuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                tipoUsuarioEncontrado.Descripcion = tipoUsuarioModelo.Descripcion;
                tipoUsuarioEncontrado.Estado = tipoUsuarioModelo.Estado;

                bool respuesta = await _catalogoTipoUsuarioRepositorio.Editar(tipoUsuarioEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar");

                return respuesta;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var usuarioEncontrado = await _catalogoTipoUsuarioRepositorio.Obtener(u => u.TipoUsuarioId == id);
                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                usuarioEncontrado.Estado = false;

                bool respuesta = await _catalogoTipoUsuarioRepositorio.Desactivar(usuarioEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se puede eliminar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CatalogoTipoUsuarioDTO>> Lista()
        {
            try
            {
                var listaTipoUsuario = await _catalogoTipoUsuarioRepositorio.Consultar();
                return _mapper.Map<List<CatalogoTipoUsuarioDTO>>(listaTipoUsuario);
            }
            catch
            {
                throw;
            }
        }
    }
}
