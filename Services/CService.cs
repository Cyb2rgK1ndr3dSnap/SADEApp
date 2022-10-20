using AutomatizacionServicios.Models.CopiasEImpresiones;
using Newtonsoft.Json;
using System.Text;

namespace AutomatizacionServicios.Services
{
    public class CService : IGetPost
    {
        public async Task<List<CopiaseImpresionesResponse>> CopiaseImpreseionesSrv(string idFac, string tipoUsuario)
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
                return copiaseImpresionesResponse;
            }
        }

        public async Task<List<CopiaseImpresionesHojasResponse>> CopiaseImpreseionesHojasSrv(string idFac)
        {
            var copiaseImpresionesResponse = new List<CopiaseImpresionesHojasResponse>();

            CopiaseImpresionesHojasRequest copiaseImpresionesRequest = new CopiaseImpresionesHojasRequest() { IdFacultad = idFac };

            StringContent content = new StringContent(JsonConvert.SerializeObject(copiaseImpresionesRequest), Encoding.UTF8, "application/json");

            using var response = await IGetPost.PostAsyncResponse("/copeimpreserv/hojas", content);

            if (response.IsSuccessStatusCode)
            {
                string json_response = response.Content.ReadAsStringAsync().Result;

                copiaseImpresionesResponse = JsonConvert.DeserializeObject<List<CopiaseImpresionesHojasResponse>>(json_response);

                return await Task.FromResult(copiaseImpresionesResponse);
            }
            else
            {
                return null;
            }
        }

        //string idUser
        public async Task<CopiaseImpresionesInsertRegisterResponse> CopiaseImpreseionesInsertRegistroSrv(string idFac, string idMaterial, string nombreCopia, int color, string idCopias, int cantidad, decimal precio)
        {
            var responseList = new List<CopiaseImpresionesInsertRegisterResponse>();

            CopiaseImpresionesInsertRegisterRequest request = new CopiaseImpresionesInsertRegisterRequest() { IdFacultad = idFac, IdUsuario = App.UserInfoDetails.Usuario_id, Token = App.UserInfoDetails.Api_token, IdMaterial = idMaterial, NombreCopia = nombreCopia, Color = color, IdCopiasEImpresiones = idCopias, Cantidad = cantidad, Precio = precio };

            StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            using var response = await IGetPost.PostAsyncResponse("/copeimpreserv/registroinsert", content);

            if (response.IsSuccessStatusCode)
            {
                string json_response = response.Content.ReadAsStringAsync().Result;

                responseList = JsonConvert.DeserializeObject<List<CopiaseImpresionesInsertRegisterResponse>>(json_response);

                return await Task.FromResult(responseList.FirstOrDefault());
            }
            else
            {
                return responseList.FirstOrDefault();
            }
        }

        public async Task<List<CopiaseImpresionesRegistrosResponse>> CopiaseImpreseionesRegistrosSrv(string idFac, string apiToken)
        {
            var responseList = new List<CopiaseImpresionesRegistrosResponse>();

            CopiaseImpresionesRegistrosRequest request = new CopiaseImpresionesRegistrosRequest() { IdFacultad = idFac, Token = apiToken };

            StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            using var response = await IGetPost.PostAsyncResponse("/copeimpreserv/registros", content);

            if (response.IsSuccessStatusCode)
            {
                string json_response = response.Content.ReadAsStringAsync().Result;

                responseList = JsonConvert.DeserializeObject<List<CopiaseImpresionesRegistrosResponse>>(json_response);

                return await Task.FromResult(responseList);
            }
            else
            {
                return responseList;
            }
        }
    }
}
