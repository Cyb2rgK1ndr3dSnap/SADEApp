namespace AutomatizacionServicios.Services
{
    public interface IGetPost
    {
        public static async Task<HttpResponseMessage> GetAsyncResponse(string ApiString)
        {
            VariabiliGlobali VarGlobal = VariabiliGlobali.Instance();
            HttpClient _client = new HttpClient();
            //Se agregó validación por token para que no haya violaciones de seguridad en la APP
            if (App.UserInfoDetails != null)
            {
                _client.DefaultRequestHeaders.Add("token", App.UserInfoDetails.Api_token);
            }
            else
            {
                _client.DefaultRequestHeaders.Add("token", "");
            }
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
            //Se agregó validación por token para que no haya violaciones de seguridad en la APP
            if (App.UserInfoDetails != null)
            {
                _client.DefaultRequestHeaders.Add("token", App.UserInfoDetails.Api_token);
            }
            else
            {
                _client.DefaultRequestHeaders.Add("token", "");
            }
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

        //Task<LoginResponse> LoginSer(string email, string password);

        //Task<List<Usuarios>> InfosSer();

        //Task<List<CopiaseImpresionesResponse>> CopiaseImpreseionesSer(string idFac, string tipoUsuario);
    }
}
