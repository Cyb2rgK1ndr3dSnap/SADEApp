namespace AutomatizacionServicios.Models.CopiasEImpresiones
{
    public class CopiaseImpresionesInsertRegisterRequest
    {
        public string IdFacultad { get; set; }

        public string IdUsuario { get; set; }

        public string Token { get; set; }

        public string IdMaterial { get; set; }

        public string NombreCopia { get; set; }

        public int Color { get; set; }

        public string IdCopiasEImpresiones { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}
