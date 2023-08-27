using GestionSolicitudes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.BLL.Servicios.Contrato
{
    public interface ICatalogoFormaEntregaService
    {
        Task<List<CatalogoFormaEntregaDTO>> Lista();
        Task<CatalogoFormaEntregaDTO> Crear(CatalogoFormaEntregaDTO modelo);
        Task<bool> Editar(CatalogoFormaEntregaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
