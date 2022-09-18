using AutomatizacionServicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.Services
{
    public interface IGetPost
    {
        public static async Task<HttpResponseMessage> GetAsyncResponse(string ApiString)
        {
            VariabiliGlobali VarGlobal = VariabiliGlobali.Instance();
            HttpClient _client = new HttpClient();
            _client.BaseAddress = VarGlobal.UriBaseAddress;
            _client.Timeout = TimeSpan.FromSeconds(30);
            try
            {
                HttpResponseMessage response = await _client.GetAsync(ApiString);
                return response;
            }
            catch (Exception ex) when (ex is TaskCanceledException || ex is OperationCanceledException)
            {
                return null;
            }
        }

        public static async Task<HttpResponseMessage> PostAsyncResponse(string ApiString, StringContent content)
        {
            VariabiliGlobali VarGlobal = VariabiliGlobali.Instance();
            HttpClient _client = new HttpClient();
            _client.BaseAddress = VarGlobal.UriBaseAddress;
            _client.Timeout = TimeSpan.FromSeconds(30);

            try
            {
                HttpResponseMessage response = await _client.PostAsync(ApiString, content);
                return response;
            }
            catch (Exception ex) when (ex is TaskCanceledException || ex is OperationCanceledException)
            {
                return null;
            }
        }

        Task<LoginResponse> LoginSer(string email, string password);

    }
}
