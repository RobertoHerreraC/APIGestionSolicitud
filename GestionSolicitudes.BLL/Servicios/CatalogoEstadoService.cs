using AutoMapper;
using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.DAL.Repositorios.Contrato;
using GestionSolicitudes.DTO;
using GestionSolicitudes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.BLL.Servicios
{
    public class CatalogoEstadoService : ICatalogoEstadoService
    {
        private readonly IGenericRepository<CatalogoEstado> _catalogoEstadoRepositorio;
        private readonly IMapper _mapper;

        public CatalogoEstadoService(IGenericRepository<CatalogoEstado> catalogoEstadoRepositorio, IMapper mapper)
        {
            _catalogoEstadoRepositorio = catalogoEstadoRepositorio;
            _mapper = mapper;
        }

        public async Task<CatalogoEstadoDTO> Crear(CatalogoEstadoDTO modelo)
        {
            try
            {
                var estadoCreado = await _catalogoEstadoRepositorio.Crear(_mapper.Map<CatalogoEstado>(modelo));

                if (estadoCreado.EstadoId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _catalogoEstadoRepositorio.Consultar(u => u.EstadoId == estadoCreado.EstadoId);
                estadoCreado = query.First();

                return _mapper.Map<CatalogoEstadoDTO>(estadoCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(CatalogoEstadoDTO modelo)
        {
            try
            {
                var estadoModelo = _mapper.Map<CatalogoEstado>(modelo);
                var estadoEncontrado = await _catalogoEstadoRepositorio.Obtener(u => u.EstadoId == estadoModelo.EstadoId);

                if (estadoEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                estadoEncontrado.Descripcion = estadoModelo.Descripcion;
                estadoEncontrado.Estado = estadoModelo.Estado;

                bool respuesta = await _catalogoEstadoRepositorio.Editar(estadoEncontrado);

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
                var estadoEncontrado = await _catalogoEstadoRepositorio.Obtener(u => u.EstadoId == id);
                if (estadoEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                estadoEncontrado.Estado = false;

                bool respuesta = await _catalogoEstadoRepositorio.Desactivar(estadoEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se puede eliminar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CatalogoEstadoDTO>> Lista()
        {
            try
            {
                var listaRol = await _catalogoEstadoRepositorio.Consultar();
                return _mapper.Map<List<CatalogoEstadoDTO>>(listaRol);
            }
            catch
            {
                throw;
            }
        }
    }
}
