using AutomatizacionServicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.Services
{
    public interface ILoginRepository
    {

        public const string ApiUrl = "https://sadeservice.000webhostapp.com";

        Task<LoginResponse> Login(string email, string password);


    }
}
