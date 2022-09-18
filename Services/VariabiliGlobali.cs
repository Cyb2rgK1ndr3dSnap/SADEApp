namespace AutomatizacionServicios.Services
{
    public class VariabiliGlobali
    {
        private Uri uriBaseAddress;

        public Uri UriBaseAddress { get => uriBaseAddress; set => uriBaseAddress = value; }

        VariabiliGlobali()
        {
            this.UriBaseAddress = new Uri("https://sadeservice.000webhostapp.com/");
        }

        public static VariabiliGlobali Instance()
        {
            return new VariabiliGlobali();
        }
    }
}