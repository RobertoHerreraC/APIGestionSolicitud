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
    public class PersonaNaturalService : IPersonaNaturalService
    {
        private readonly IGenericRepository<PersonaNatural> _personaNaturalRepositorio;
        private readonly IMapper _mapper;

        public PersonaNaturalService(IGenericRepository<PersonaNatural> personaNaturalRepositorio, IMapper mapper)
        {
            _personaNaturalRepositorio = personaNaturalRepositorio;
            _mapper = mapper;
        }

        public async Task<PersonaNaturalDTO> Crear(PersonaNaturalDTO modelo)
        {
            try
            {
                var personaNaturalCreado = await _personaNaturalRepositorio.Crear(_mapper.Map<PersonaNatural>(modelo));

                if (personaNaturalCreado.PersonaNaturalId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _personaNaturalRepositorio.Consultar(u => u.PersonaNaturalId == personaNaturalCreado.PersonaNaturalId);
                personaNaturalCreado = query.First();

                return _mapper.Map<PersonaNaturalDTO>(personaNaturalCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(PersonaNaturalDTO modelo)
        {
            try
            {
                var personaModelo = _mapper.Map<PersonaNatural>(modelo);
                var personaEncontrado = await _personaNaturalRepositorio.Obtener(u => u.PersonaNaturalId == personaModelo.PersonaNaturalId);

                if (personaEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                personaEncontrado.Nombres = personaModelo.Nombres;
                personaEncontrado.ApellidoPaterno = personaModelo.ApellidoPaterno;
                personaEncontrado.ApellidoMaterno = personaModelo.ApellidoMaterno;
                personaEncontrado.NroDocumento = personaModelo.NroDocumento;
                personaEncontrado.TipoDocumento = personaModelo.TipoDocumento;

                bool respuesta = await _personaNaturalRepositorio.Editar(personaEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar");

                return respuesta;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PersonaNaturalDTO>> Lista()
        {
            try
            {
                var listaRol = await _personaNaturalRepositorio.Consultar();
                return _mapper.Map<List<PersonaNaturalDTO>>(listaRol);
            }
            catch
            {
                throw;
            }
        }
    }
}
