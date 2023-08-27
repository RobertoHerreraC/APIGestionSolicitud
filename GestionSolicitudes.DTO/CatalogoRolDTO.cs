using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DTO
{
    public class CatalogoRolDTO
    {
        public int RolId { get; set; }
        public string NombreRol { get; set; } = null!;
        public int? Activo { get; set; } = 1;
    }
}
