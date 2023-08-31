using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSolicitudes.Model
{
    public class ResultadoPersonaAPI
    {
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string digitoVerificador { get; set; }
    }
}
