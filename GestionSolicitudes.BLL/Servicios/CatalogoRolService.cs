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
    public class CatalogoRolService : ICatalogoRolService
    {
        private readonly IGenericRepository<CatalogoRol> _catalogoRolRepositorio;
        private readonly IMapper _mapper;

        public CatalogoRolService(IGenericRepository<CatalogoRol> catalogoRolRepositorio, IMapper mapper)
        {
            _catalogoRolRepositorio = catalogoRolRepositorio;
            _mapper = mapper;
        }

        public async Task<CatalogoRolDTO> Crear(CatalogoRolDTO modelo)
        {
            try
            {
                var rolCreado = await _catalogoRolRepositorio.Crear(_mapper.Map<CatalogoRol>(modelo));

                if (rolCreado.RolId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _catalogoRolRepositorio.Consultar(u => u.RolId == rolCreado.RolId);
                rolCreado = query.First();

                return _mapper.Map<CatalogoRolDTO>(rolCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(CatalogoRolDTO modelo)
        {
            try
            {
                var rolModelo = _mapper.Map<CatalogoRol>(modelo);
                var rolEncontrado = await _catalogoRolRepositorio.Obtener(u => u.RolId == rolModelo.RolId);

                if (rolEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                rolEncontrado.NombreRol = rolModelo.NombreRol;
                rolEncontrado.Estado = rolModelo.Estado;

                bool respuesta = await _catalogoRolRepositorio.Editar(rolEncontrado);

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
                var rolEncontrado = await _catalogoRolRepositorio.Obtener(u => u.RolId == id);
                if (rolEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                rolEncontrado.Estado = false;

                bool respuesta = await _catalogoRolRepositorio.Desactivar(rolEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se puede eliminar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CatalogoRolDTO>> Lista()
        {
            try
            {
                var listaRol = await _catalogoRolRepositorio.Consultar();
                return _mapper.Map<List<CatalogoRolDTO>>(listaRol);
            }
            catch
            {
                throw;
            }
        }
    }
}
