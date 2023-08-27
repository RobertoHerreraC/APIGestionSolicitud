using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DTO
{
    public class TareaDTO
    {
        public int TareaId { get; set; }

        public string Descripcion { get; set; } = null!;

        public int? EstadoId { get; set; }
        public string? DescripcionEstado { get; set; }

        public int? Activo { get; set; }


        /*public virtual ICollection<Bitacora> Bitacoras { get; set; } = new List<Bitacora>();*/

       /* public virtual CatalogoEstadoDTO? EstadoNav { get; set; }*/
    }
}
