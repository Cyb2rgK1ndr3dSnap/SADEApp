using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.Models.CopiasEImpresiones
{
    public class CopiaseImpresionesInsertRegisterRequest
    {
        public string IdFacultad { get; set; }

        public string IdUsuario { get; set; }

        public string IdMaterial { get; set; }

        public string NombreCopia { get; set; }

        public int Color { get; set; }

        public string IdCopiasEImpresiones { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}
