using AutomatizacionServicios.Models.CopiasEImpresiones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return null;
            }
        }

        public async Task<List<CopiaseImpresionesHojasResponse>> CopiaseImpreseionesHojasSrv(string idFac)
        {
            var copiaseImpresionesResponse = new List<CopiaseImpresionesHojasResponse>();

            CopiaseImpresionesHojasRequest copiaseImpresionesRequest = new CopiaseImpresionesHojasRequest() { IdFacultad = idFac};

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

        public async Task<CopiaseImpresionesInsertRegisterResponse> CopiaseImpreseionesInsertRegistroSrv(string idFac, string idUser, string idMaterial, string nombreCopia, int color, string idCopias,int cantidad,decimal precio)
        {
            var responseList = new List<CopiaseImpresionesInsertRegisterResponse>();

            CopiaseImpresionesInsertRegisterRequest request = new CopiaseImpresionesInsertRegisterRequest() { IdFacultad = idFac,IdUsuario =idUser,IdMaterial= idMaterial,NombreCopia = nombreCopia,Color = color,IdCopiasEImpresiones= idCopias,Cantidad= cantidad, Precio=precio};

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
                return null;
            }
        }

        public async Task<List<CopiaseImpresionesRegistrosResponse>> CopiaseImpreseionesRegistrosSrv(string idFac, string idUser)
        {
            var responseList = new List<CopiaseImpresionesRegistrosResponse>();

            CopiaseImpresionesRegistrosRequest request = new CopiaseImpresionesRegistrosRequest() { IdFacultad = idFac, IdUsuario = idUser};

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
                return null;
            }
        }
    }
}
