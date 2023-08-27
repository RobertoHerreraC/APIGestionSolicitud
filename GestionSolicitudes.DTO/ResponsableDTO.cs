using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.DTO
{
    public class ResponsableDTO
    {
        public int ResponsableId { get; set; }
        public string? Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public int PersonaNaturalId { get; set; }
        public string? NombreArea { get; set; }
       
    }
}
