using AutomatizacionServicios.Models.Token;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.Services
{
    public class TService : IGetPost
    {
        public async Task<BilleteraResponse> Billetera()
        {
            var billeteraResponse = new List<BilleteraResponse>();

            BilleteraRequest TokenRequest = new BilleteraRequest() {Api_token = App.UserInfoDetails.Api_token};

            StringContent content = new StringContent(JsonConvert.SerializeObject(TokenRequest), Encoding.UTF8, "application/json");

            using var response = await IGetPost.PostAsyncResponse("/billetera", content);

            if (response.IsSuccessStatusCode)
            {
                string json_response = response.Content.ReadAsStringAsync().Result;

                billeteraResponse = JsonConvert.DeserializeObject<List<BilleteraResponse>>(json_response);

                return await Task.FromResult(billeteraResponse.FirstOrDefault());
            }
            else
            {
                return null;
            }
        }
    }
}
