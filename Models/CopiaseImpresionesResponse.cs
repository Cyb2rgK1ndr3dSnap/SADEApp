﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.Models
{
    public class CopiaseImpresionesResponse
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public int Corta { get; set; }

        public int Larga { get; set; }

        public int Color { get; set; }
    }
}
