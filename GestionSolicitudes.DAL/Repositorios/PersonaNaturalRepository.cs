using GestionSolicitudes.DAL.DBContext;
using GestionSolicitudes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DAL.Repositorios
{
    public class PersonaNaturalRepository : GenericRepository<PersonaNatural>
    {
        private readonly BdegemsaContext _dbcontext;

        public PersonaNaturalRepository(BdegemsaContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
