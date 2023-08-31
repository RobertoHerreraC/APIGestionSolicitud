using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestionSolicitudes.DAL.DBContext;
using GestionSolicitudes.DAL.Repositorios.Contrato;
using GestionSolicitudes.Model;
using Microsoft.IdentityModel.Abstractions;

namespace GestionSolicitudes.DAL.Repositorios
{
    public class SolicitudRepository : GenericRepository<Solicitud>, ISolicitudRepository
    {
        private readonly BdegemsaContext _dbcontext;

        public SolicitudRepository(BdegemsaContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Solicitud> Alta(Solicitud solicitud)
        {
            Solicitud solicitudGenerada = new Solicitud();

            using (var transaction = _dbcontext.Database.BeginTransaction()) 
            {
                try
                {
                    /*NumeroCorrelativo correlativo = _dbcontext.NumeroCorrelativos.First();
                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaActulizacion = DateTime.Now;

                    _dbcontext.NumeroCorrelativos.Update(correlativo);
                    await _dbcontext.SaveChangesAsync();

                    int CantidadDigitos = 8;
                    string ceros = string.Concat(Enumerable.Repeat("0", CantidadDigitos));
                    string numeroSolicitud = ceros + correlativo.UltimoNumero.ToString();

                    numeroSolicitud = numeroSolicitud.Substring(numeroSolicitud.Length - CantidadDigitos, CantidadDigitos);*/

                    if (solicitud.PersonaNatural != null && solicitud.PersonaJuridica == null)
                    {
                        
                        
                        var personaNaturalRepository = new PersonaNaturalRepository(_dbcontext);
                        var queryPersonaNatural = await personaNaturalRepository.Consultar(s => s.NroDocumento == solicitud.PersonaNatural.NroDocumento && 
                                                        s.TipoDocumento == solicitud.PersonaNatural.TipoDocumento);

                        var personaNatural = queryPersonaNatural.FirstOrDefault();

                        if (personaNatural == null)
                        {
                            personaNatural = await personaNaturalRepository.Crear(solicitud.PersonaNatural);
                            
                        }

                        solicitud.PersonaNatural = personaNatural;

                    }



                    await _dbcontext.Solicituds.AddAsync(solicitud);
                    await _dbcontext.SaveChangesAsync();

                    Bitacora bitacora = new Bitacora();
                    bitacora.SolicitudId = solicitud.SolicitudId;

                    var bitacoraRepository = new BitacoraRepository(_dbcontext);
                    await bitacoraRepository.Inicio(bitacora);
                    await _dbcontext.SaveChangesAsync();

                    solicitudGenerada = solicitud;

                    transaction.CommitAsync();
                    //return solicitudGenerada;

                }
                catch
                {
                    //(Exception ex2)
                    //Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    //Console.WriteLine("  Message: {0}", ex2.Message);
                    transaction.RollbackAsync();
                    throw;
                }
                //finally
                //{
                //    transaction.Dispose();
                //}
                return solicitudGenerada;
            }

        }
    }
}
