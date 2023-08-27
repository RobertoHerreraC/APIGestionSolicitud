using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DTO
{
    public class PersonaNaturalDTO
    {
        public int PersonaNaturalId { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string NroDocumento { get; set; } = null!;
        public string TipoDocumento { get; set; } = null!;
        
    }
}
