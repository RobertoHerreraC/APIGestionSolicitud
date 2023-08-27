using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DTO
{
    public class CatalogoFormaEntregaDTO
    {
        public int FormaEntregaId { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? GeneraCosto { get; set; } = 1;
    }
}
