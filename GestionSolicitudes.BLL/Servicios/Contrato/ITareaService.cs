using GestionSolicitudes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.BLL.Servicios.Contrato
{
    public interface ITareaService
    {
        Task<List<TareaDTO>> Lista();
        Task<TareaDTO> Crear(TareaDTO modelo);
        Task<bool> Editar(TareaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
