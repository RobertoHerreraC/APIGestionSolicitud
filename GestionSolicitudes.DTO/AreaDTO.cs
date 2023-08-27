using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DTO
{
    public class AreaDTO
    {
        public int AreaId { get; set; }
        public int TipoUsuarioId { get; set; }
        public string Nombre { get; set; } = null!;
        public bool? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
