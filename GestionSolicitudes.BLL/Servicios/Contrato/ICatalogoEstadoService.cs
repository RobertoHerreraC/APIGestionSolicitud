using GestionSolicitudes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.BLL.Servicios.Contrato
{
    public interface ICatalogoEstadoService
    {
        Task<List<CatalogoEstadoDTO>> Lista();
        Task<CatalogoEstadoDTO> Crear(CatalogoEstadoDTO modelo);
        Task<bool> Editar(CatalogoEstadoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
