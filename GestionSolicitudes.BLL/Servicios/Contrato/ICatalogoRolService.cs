using GestionSolicitudes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.BLL.Servicios.Contrato
{
    public interface ICatalogoRolService
    {
        Task<List<CatalogoRolDTO>> Lista();
        Task<CatalogoRolDTO> Crear(CatalogoRolDTO modelo);
        Task<bool> Editar(CatalogoRolDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
