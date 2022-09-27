﻿using AutomatizacionServicios.Models;
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
        public async Task<List<Usuarios>> InfosSer()
        {
            var infosResponse = new List<Usuarios>();

            using var response = await IGetPost.GetAsyncResponse("/infos");

            if (response.IsSuccessStatusCode)
            {
                string json_response = response.Content.ReadAsStringAsync().Result;

                infosResponse = JsonConvert.DeserializeObject<List<Usuarios>>(json_response);

                return await Task.FromResult(infosResponse);
            }
            else
            {
                return null;
            }
        }

        //LoginPrueba
        public async Task<LoginResponse> LoginSer(string email, string password)
        {
            var loginResponse = new List<LoginResponse>();

            LoginRequest loginRequest = new LoginRequest() { Correo = email, Contrasena = password };

            StringContent content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

            using var response = await IGetPost.PostAsyncResponse("/login",content);

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

        public async Task<List<CopiaseImpresionesResponse>> CopiaseImpreseionesSer(string idFac, string tipoUsuario) 
        {
            var copiaseImpresionesResponse = new List<CopiaseImpresionesResponse>();

            CopiaseImpresionesRequest copiaseImpresionesRequest = new CopiaseImpresionesRequest() { IdFacultad = idFac, TipoUsuarioId = tipoUsuario };

            StringContent content = new StringContent(JsonConvert.SerializeObject(copiaseImpresionesRequest), Encoding.UTF8, "application/json");

            using var response = await IGetPost.PostAsyncResponse("/copeimpreserv", content);

            if (response.IsSuccessStatusCode)
            {
                string json_response = response.Content.ReadAsStringAsync().Result;

                copiaseImpresionesResponse = JsonConvert.DeserializeObject<List<CopiaseImpresionesResponse>>(json_response);

                return await Task.FromResult(copiaseImpresionesResponse);
            }
            else
            {
                return null;
            }

        }



    }
}
