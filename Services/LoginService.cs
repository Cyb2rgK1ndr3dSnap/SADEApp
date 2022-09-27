using AutomatizacionServicios.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.Services
{
    public class LoginService : ILoginRepository
    {

        public async Task<LoginResponse> Login(string email, string password)
        {
            var loginResponse = new List<LoginResponse>();
            HttpClient client = new HttpClient();

            Uri url = new Uri (ILoginRepository.ApiUrl+"/login");

            //client.BaseAddress = url;

            LoginRequest loginRequest = new LoginRequest(){ Correo = email, Contrasena = password };

            StringContent content = new StringContent(JsonConvert.SerializeObject(loginRequest),Encoding.UTF8,"application/json");

            using var response = await client.PostAsync(url,content);

            client.DefaultRequestHeaders.Accept.Clear();

            if (response.IsSuccessStatusCode)
            {
                string json_response = response.Content.ReadAsStringAsync().Result;

                loginResponse = JsonConvert.DeserializeObject<List<LoginResponse>>(json_response);

                return await Task.FromResult(loginResponse.FirstOrDefault());
            }
            else
            {
                return null;
            }
        }
    }
}
