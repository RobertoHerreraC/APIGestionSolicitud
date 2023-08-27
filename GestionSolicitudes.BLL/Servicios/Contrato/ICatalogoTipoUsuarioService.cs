using GestionSolicitudes.DTO;

namespace GestionSolicitudes.API.BLL.Servicio.Contrato
{
    public interface ICatalogoTipoUsuarioService
    {
        Task<List<CatalogoTipoUsuarioDTO>> Lista();
        Task<CatalogoTipoUsuarioDTO> Crear(CatalogoTipoUsuarioDTO modelo);
        Task<bool> Editar(CatalogoTipoUsuarioDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
