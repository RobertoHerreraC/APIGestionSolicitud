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
    public class PersonaJuridicaService : IPersonaJuridicaService
    {
        private readonly IGenericRepository<PersonaJuridica> _personaJuridicaRepositorio;
        private readonly IMapper _mapper;

        public PersonaJuridicaService(IGenericRepository<PersonaJuridica> personaJuridicaRepositorio, IMapper mapper)
        {
            _personaJuridicaRepositorio = personaJuridicaRepositorio;
            _mapper = mapper;
        }

        public async Task<PersonaJuridicaDTO> Crear(PersonaJuridicaDTO modelo)
        {
            try
            {
                var personaJuridicaCreado = await _personaJuridicaRepositorio.Crear(_mapper.Map<PersonaJuridica>(modelo));

                if (personaJuridicaCreado.PersonaJuridicaId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _personaJuridicaRepositorio.Consultar(u => u.PersonaJuridicaId == personaJuridicaCreado.PersonaJuridicaId);
                personaJuridicaCreado = query.First();

                return _mapper.Map<PersonaJuridicaDTO>(personaJuridicaCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(PersonaJuridicaDTO modelo)
        {
            try
            {
                var personaModelo = _mapper.Map<PersonaJuridica>(modelo);
                var personaEncontrado = await _personaJuridicaRepositorio.Obtener(u => u.PersonaJuridicaId == personaModelo.PersonaJuridicaId);

                if (personaEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                personaEncontrado.Ruc = personaModelo.Ruc;
                personaEncontrado.RazonSocial = personaModelo.RazonSocial;

                bool respuesta = await _personaJuridicaRepositorio.Editar(personaEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar");

                return respuesta;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PersonaJuridicaDTO>> Lista()
        {
            try
            {
                var listaPersona = await _personaJuridicaRepositorio.Consultar();
                return _mapper.Map<List<PersonaJuridicaDTO>>(listaPersona);
            }
            catch
            {
                throw;
            }
        }
    }
}
