using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace GestionSolicitudes.DAL.Repositorios.Contrato
{
    public interface IGenericRepository<TModelo> where TModelo : class
    {
        Task<TModelo> Obtener(Expression<Func<TModelo, bool>> filtro);
        Task<TModelo> Crear(TModelo modelo);
        Task<bool> Editar(TModelo modelo);
        Task<bool> Desactivar(TModelo modelo);
        Task<IQueryable<TModelo>> Consultar(Expression<Func<TModelo,bool>> filtro = null);
    }
}
