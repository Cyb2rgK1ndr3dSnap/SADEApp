using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.Models
{
    public class LoginResponse
    {
        public string nombre { get; set; }

        public string apellido { get; set; }

        public string usuario_id { get; set; }

        public string tipo_usuario_id { get; set; }

        public string cedula { get; set; }

        public string correo { get; set; }
    }
}
