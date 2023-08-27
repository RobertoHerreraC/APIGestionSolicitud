using AutoMapper;
using GestionSolicitudes.BLL.Servicios.Contrato;
using GestionSolicitudes.DAL.Repositorios.Contrato;
using GestionSolicitudes.DTO;
using GestionSolicitudes.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.BLL.Servicios
{
    public class CatalogoFormaEntregaService : ICatalogoFormaEntregaService
    {
        private readonly IGenericRepository<CatalogoFormaEntrega> _catalogoFormaEntregaRepositorio;
        private readonly IMapper _mapper;

        public CatalogoFormaEntregaService(IGenericRepository<CatalogoFormaEntrega> catalogoFormaEntregaRepositorio, IMapper mapper)
        {
            _catalogoFormaEntregaRepositorio = catalogoFormaEntregaRepositorio;
            _mapper = mapper;
        }

        public async Task<CatalogoFormaEntregaDTO> Crear(CatalogoFormaEntregaDTO modelo)
        {
            try
            {
                var formaEntregaCreado = await _catalogoFormaEntregaRepositorio.Crear(_mapper.Map<CatalogoFormaEntrega>(modelo));

                if (formaEntregaCreado.FormaEntregaId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _catalogoFormaEntregaRepositorio.Consultar(u => u.FormaEntregaId == formaEntregaCreado.FormaEntregaId);
                formaEntregaCreado = query.First();

                return _mapper.Map<CatalogoFormaEntregaDTO>(formaEntregaCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(CatalogoFormaEntregaDTO modelo)
        {
            try
            {
                var formaEntregaModelo = _mapper.Map<CatalogoFormaEntrega>(modelo);
                var formaEntregaEncontrado = await _catalogoFormaEntregaRepositorio.Obtener(u => u.FormaEntregaId == formaEntregaModelo.FormaEntregaId);

                if (formaEntregaEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                formaEntregaEncontrado.Descripcion = formaEntregaModelo.Descripcion;
                formaEntregaEncontrado.Estado = formaEntregaModelo.Estado;

                bool respuesta = await _catalogoFormaEntregaRepositorio.Editar(formaEntregaEncontrado);

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
                var formaEntregaEncontrado = await _catalogoFormaEntregaRepositorio.Obtener(u => u.FormaEntregaId == id);
                if (formaEntregaEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                formaEntregaEncontrado.Estado = false;

                bool respuesta = await _catalogoFormaEntregaRepositorio.Desactivar(formaEntregaEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se puede eliminar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CatalogoFormaEntregaDTO>> Lista()
        {
            var ListaResultado = new List<CatalogoFormaEntrega>();
            try
            {
                
                IQueryable<CatalogoFormaEntrega> query = await _catalogoFormaEntregaRepositorio.Consultar();
                ListaResultado = await query.Where(r => 
                    r.Estado == true).ToListAsync();
                return _mapper.Map<List<CatalogoFormaEntregaDTO>>(ListaResultado);
            }
            catch
            {
                throw;
            }

        }
    }
}
