using AutomatizacionServicios.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;


namespace AutomatizacionServicios.Services
{
    public class LServices : IGetPost
    {
        //LoginPrueba
        public async Task<LoginResponse> LoginSer(string email, string password)
        {
            var loginResponse = new List<LoginResponse>();

            LoginRequest loginRequest = new LoginRequest() { correo = email, contrasena = password };

            StringContent content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

            using var response = await IGetPost.PostAsyncResponse("/login",content);

            /*string json_response = response.Content.ReadAsStringAsync().Result;

            loginResponse = JsonConvert.DeserializeObject<List<LoginResponse>>(json_response);*/
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
