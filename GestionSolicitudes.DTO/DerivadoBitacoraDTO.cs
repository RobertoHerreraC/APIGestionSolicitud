using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DTO
{
    public class DerivadoBitacoraDTO
    {
        public int DerivadoId { get; set; }
        public int? ResponsableId { get; set; }
        public string? Responsable { get; set; }
        public int? PeticionId { get; set; }
        public string? Peticion { get; set; }
        /*public int? BitacoraPeticionId { get; set; }
        public int? BitacoraRespuestaPeticionId { get; set; }*/
    }
}
