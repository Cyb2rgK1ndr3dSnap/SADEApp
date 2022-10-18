using AutomatizacionServicios.Models.Startup;

namespace AutomatizacionServicios.Services
{
    public interface ILoginRepository
    {

        public const string ApiUrl = "https://sadeservice.000webhostapp.com";

        Task<LoginResponse> Login(string email, string password);


    }
}
