using AppTreinoCarlos.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppTreinoCarlos.Services
{
    public class CommFunctions
    {
        private readonly IConfiguration Configuration;
        static AppConfigs _constants;
        public CommFunctions(IConfiguration configuration)
        {
            Configuration = configuration;
            _constants = new AppConfigs(Configuration);
        }

        private string BaseUrl()
        {
            return _constants._BaseUrl;
        }

        private string BuildCall(HttpClient httpClient, string endPoint)
        {
            var url = $"{BaseUrl()}{endPoint}";
            httpClient.DefaultRequestHeaders.Add("token", _constants._TokenBackend);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return url;
        }


        public Instrutor Login(Credential obj)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "login");
                    var apiResult =
                        JsonConvert.DeserializeObject<Instrutor>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );

                    var usuario = apiResult;

                    //CODE Criptografa senha para guardar local já que a senha não é retornada. Melhor que seja assim.
                    //var shield = new Shield(CryptProvider.Rijndael);
                    //usuario.Senha = shield.Lock(obj.Senha);

                    return usuario;
                }
            }
            catch (Exception)
            {
                throw new Exception("Usuário ou senha inválidos.");
            }
        }






        public Boolean UsuarioAtivo(Credential obj)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "usuarioAtivo");
                    var apiResult =
                        JsonConvert.DeserializeObject<string>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );

                    var usuario = apiResult == "Ativo" ? true : false;

                    ////Criptografa senha para guardar local já que a senha não é retornada. Melhor que seja assim.
                    //var shield = new Shield(CryptProvider.Rijndael);
                    //usuario.Senha = shield.Lock(obj.Senha);

                    return usuario;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}


