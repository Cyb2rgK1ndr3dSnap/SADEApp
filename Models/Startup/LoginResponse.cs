using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.Models.Startup
{
    public class LoginResponse
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        //public string Apellido { get; set; }

        public string Usuario_id { get; set; }

        public string Tipo_usuario_id { get; set; }

        public string Cedula { get; set; }

        public string Correo { get; set; }

        public string Facultad_id { get; set; }

        public string Api_token { get; set; }
    }
}
