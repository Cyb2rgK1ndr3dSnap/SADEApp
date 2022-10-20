using AutomatizacionServicios.Models.Materiales;
using Newtonsoft.Json;
using System.Text;

namespace AutomatizacionServicios.Services
{
    public class MService : IGetPost
    {

        public async Task<List<MaterialesResponse>> MaterialesServ()
        {
            var materialesResponse = new List<MaterialesResponse>();

            MaterialesRequest materialesRequest = new MaterialesRequest() { IdFacultad = App.UserInfoDetails.Facultad_id };

            StringContent content = new StringContent(JsonConvert.SerializeObject(materialesRequest), Encoding.UTF8, "application/json");

            using var response = await IGetPost.PostAsyncResponse("/materialesserv", content);

            if (response.IsSuccessStatusCode)
            {
                string json_response = response.Content.ReadAsStringAsync().Result;

                materialesResponse = JsonConvert.DeserializeObject<List<MaterialesResponse>>(json_response);

                return await Task.FromResult(materialesResponse);
            }
            else
            {
                return materialesResponse;
            }
        }

        public async Task<MaterialesAddResponse> MaterialAdd(string nombreMaterial, string otro, string colorNombre, int color, int corta, int larga )
        {
            var materialResponse = new List<MaterialesAddResponse>();

            MaterialesAddRequest materialesRequest = new MaterialesAddRequest() {Api_token=App.UserInfoDetails.Api_token, IdFacultad = App.UserInfoDetails.Facultad_id, NombreMaterial=nombreMaterial, Otro=otro, ColorNombre=colorNombre, Color=color, Corta=corta, Larga=larga };

            StringContent content = new StringContent(JsonConvert.SerializeObject(materialesRequest), Encoding.UTF8, "application/json");

            using var response = await IGetPost.PostAsyncResponse("/materiales/insert", content);

            if (response.IsSuccessStatusCode)
            {
                string json_response = response.Content.ReadAsStringAsync().Result;

                materialResponse = JsonConvert.DeserializeObject<List<MaterialesAddResponse>>(json_response);

                return await Task.FromResult(materialResponse.FirstOrDefault());
            }
            else
            {
                return materialResponse.FirstOrDefault();
            }
        }
    }
}
