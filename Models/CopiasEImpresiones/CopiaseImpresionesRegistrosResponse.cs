using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.Models.CopiasEImpresiones
{
    public class CopiaseImpresionesRegistrosResponse
    {
        public string Id { get; set; }

        public string Usuario_Id { get; set; }

        public string Material_copiado_nombre { get; set; }

        public string Nombre { get; set; }

        public string Matnombre { get; set; }

        public string Gastado { get; set; }

        public string Precio { get; set; }

        public string Tarea { get; set; }

        public string Pagado { get; set; }

        public string Estado { get; set; }

        public string StateImage { get; set; }
    }
}
