using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DTO
{
    public class CatalogoEstadoDTO
    {
        public int EstadoId { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? Activo { get; set; } = 1;
    }
}
