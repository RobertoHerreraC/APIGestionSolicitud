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
    public class TareaService : ITareaService
    {
        private readonly IGenericRepository<Tarea> _tareaRepositorio;
        private readonly IMapper _mapper;

        public TareaService(IGenericRepository<Tarea> tareaRepositorio, IMapper mapper)
        {
            _tareaRepositorio = tareaRepositorio;
            _mapper = mapper;
        }

        public async Task<TareaDTO> Crear(TareaDTO modelo)
        {
            try
            {
                var tareaCreada = await _tareaRepositorio.Crear(_mapper.Map<Tarea>(modelo));

                if (tareaCreada.TareaId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _tareaRepositorio.Consultar(u => u.TareaId == tareaCreada.TareaId);
                tareaCreada = query.First();

                return _mapper.Map<TareaDTO>(tareaCreada);
            }
            catch
            {
                throw;
            }
        }

        public Task<bool> Editar(TareaDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TareaDTO>> Lista()
        {
            try
            {
                var queryTareas = await _tareaRepositorio.Consultar();
                var listaTareas = queryTareas.Include(tarea => tarea.EstadoNavigation).ToList();
                return _mapper.Map<List<TareaDTO>>(listaTareas);


              
            }
            catch
            {
                throw;
            }
        }
    }
}
