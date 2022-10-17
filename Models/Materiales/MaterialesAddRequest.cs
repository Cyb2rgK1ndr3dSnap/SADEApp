using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.Models.Materiales
{
    public class MaterialesAddRequest
    {
        public string IdFacultad { get; set; }

        public string NombreMaterial { get; set; }

        public int Larga { get; set; }

        public int Corta { get; set; }

        public int Color { get; set; }

        public string ColorNombre { get; set; }

        public string Otro { get; set; }

        public int Tipo_Usuario { get; set; }
    }
}
