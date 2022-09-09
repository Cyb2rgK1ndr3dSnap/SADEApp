﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.Models
{
    internal class RegisterRequest
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Correo { get; set; }

        public string Contrasena { get; set; }

        public string Cedula { get; set; }

        public string Facultad { get; set; }

        public string Carrera { get; set; }
    }
}
