﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.Models.CopiasEImpresiones
{
    public class CopiaseImpresionesResponse
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public decimal Costo { get; set; }

        public bool Color { get; set; }
    }
}