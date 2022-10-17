using AutomatizacionServicios.Models.CopiasEImpresiones;
using AutomatizacionServicios.Models.Materiales;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.Services
{
    public class MService : IGetPost
    {
        
        public async Task<List<MaterialesResponse>> AddMateriales()
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
                return null;
            }
        }
    }
}
