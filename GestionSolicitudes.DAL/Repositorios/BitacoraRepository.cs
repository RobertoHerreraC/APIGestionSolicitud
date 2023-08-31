using GestionSolicitudes.DAL.DBContext;
using GestionSolicitudes.DAL.Repositorios.Contrato;
using GestionSolicitudes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DAL.Repositorios
{
    public class BitacoraRepository : GenericRepository<Bitacora>, IBitacoraRepository
    {
        private readonly BdegemsaContext _dbcontext;

        public BitacoraRepository(BdegemsaContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Bitacora> Inicio(Bitacora bitacora)
        {
            bitacora.TareaId = 1;
            bitacora.FechaHoraAccion = DateTime.Now;
            
            await _dbcontext.Bitacoras.AddAsync(bitacora);
            await _dbcontext.SaveChangesAsync();

            return bitacora;
        }
    }
}
