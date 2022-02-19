using AppTreinoCarlos.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
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

        public Instrutor Login(string email, string senha)
        {
            try
            {
                dynamic obj = new ExpandoObject();
                obj.usuario = email;
                obj.senha = senha;
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "Login");
                    var apiResult =
                        JsonConvert.DeserializeObject<ResponseService<Instrutor>>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    //var x = httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;

                    var usuario = apiResult;

                    //CODE Criptografa senha para guardar local já que a senha não é retornada. Melhor que seja assim.
                    //var shield = new Shield(CryptProvider.Rijndael);
                    //usuario.Senha = shield.Lock(obj.Senha);

                    return usuario.Data;
                }
            }
            catch (Exception)
            {
                throw new Exception("Usuário ou senha inválidos.");
            }
        }
        public List<Atleta> GetAtletasCompletos(string idAtleta, string idInstrutor)
        {
            try
            {
                dynamic obj = new ExpandoObject();
                obj.idAtleta = idAtleta;
                obj.idInstrutor = idInstrutor;
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "GET_ATLETAS_COMPLETO");
                    var apiResult =
                        JsonConvert.DeserializeObject<ResponseService<List<Atleta>>>(
                        httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    return apiResult.Data;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public List<TreinoAtletas> GetAtletasTreino(string idTreino)
        {
            try
            {
                dynamic obj = new ExpandoObject();
                obj.idTreino = idTreino;
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "GET_ATLETAS_TREINO");
                    var apiResult =
                        JsonConvert.DeserializeObject<ResponseService<List<TreinoAtletas>>>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    return apiResult.Data;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public List<Avaliacao> GetAvaliacoesTreino(string idTreino, string idAtleta)
        {
            try
            {
                dynamic obj = new ExpandoObject();
                obj.idTreino = idTreino;
                obj.idAtleta = idAtleta;
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "GET_AVALIACOES_TREINO");
                    var apiResult =
                        JsonConvert.DeserializeObject<ResponseService<List<Avaliacao>>>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    return apiResult.Data;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public List<Treino> GetTreino(string idTreino, string idInstrutor)
        {
            try
            {
                dynamic obj = new ExpandoObject();
                obj.idTreino = idTreino;
                obj.idInstrutor = idInstrutor;
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "GET_TREINO");
                    var apiResult =
                        JsonConvert.DeserializeObject<ResponseService<List<Treino>>>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    return apiResult.Data;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public List<Topico> GetTopicos(string idInstrutor)
        {
            try
            {
                dynamic obj = new ExpandoObject();
                obj.idInstrutor = idInstrutor;
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "GET_TOPICOS");
                    var apiResult =
                        JsonConvert.DeserializeObject<ResponseService<List<Topico>>>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    return apiResult.Data;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public bool DelTreinoAtleta(string treinoID, string atletaID)
        {
            try
            {
                dynamic obj = new ExpandoObject();
                obj.atletaID = treinoID;
                obj.atletaID = atletaID;
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "DEL_TREINO_ATLETA");
                    var apiResult =
                        JsonConvert.DeserializeObject<bool>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    return apiResult;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public bool SetAtleta(Atleta atleta)
        {
            try
            {
                dynamic obj = new ExpandoObject();
                obj.atleta = atleta;
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "SET_ATLETA");
                    var apiResult =
                        JsonConvert.DeserializeObject<bool>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    return apiResult;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public bool inativaAtleta(string atletaid)
        {
            try
            {
                dynamic obj = new ExpandoObject();
                obj.atletaId = atletaid;
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "INATIVA_ATLETA");
                    var apiResult =
                        JsonConvert.DeserializeObject<ResponseService<bool>>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    return apiResult.Data;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public bool SetTreinoInstrutor(TreinoInstrutor treinoAtletas)
        {
            try
            {

                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "SET_TREINO_INSTRUTOR");
                    var apiResult =
                        JsonConvert.DeserializeObject<ResponseService<bool>>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(treinoAtletas), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    return apiResult.Data;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public bool SetAvaliacao(Avaliacao avaliacao)
        {
            try
            {   
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "SET_AVALIACAO");
                    var apiResult =
                        JsonConvert.DeserializeObject<ResponseService<bool>>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(avaliacao), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    return apiResult.Data;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public bool SetInstrutor(Instrutor instrutor)
        {
            try
            {
                dynamic obj = new ExpandoObject();
                obj.instrutor = instrutor;
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "SET_INSTRUTOR");
                    var apiResult =
                        JsonConvert.DeserializeObject<bool>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    return apiResult;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public bool SetTopicos(Topico topico)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "SET_TOPICOS");
                    var apiResult =
                        JsonConvert.DeserializeObject<ResponseService<bool>>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(topico), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    return apiResult.Data;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public string SetTreino(Treino obj)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "SET_TREINO");
                    var apiResult =
                        JsonConvert.DeserializeObject<ResponseService<string>>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    //apiResult = SetTreinoInstrutor(apiResult.Data.Id, treino);
                    return apiResult.Data;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public string SetTreinoAtleta(string Idtreino, string idAtleta)
        {
            try
            {
                dynamic obj = new ExpandoObject();
                obj.treinoID = Idtreino;
                obj.atletaID = idAtleta;
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "SET_TREINO_ATLETA");
                    var apiResult =
                        JsonConvert.DeserializeObject<ResponseService<string>>(
                            httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    return apiResult.Data;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        //public Boolean UsuarioAtivo(Credential obj)
        //{
        //    try
        //    {
        //        using (var httpClient = new HttpClient())
        //        {
        //            var url = BuildCall(httpClient, "usuarioAtivo");
        //            var apiResult =
        //                JsonConvert.DeserializeObject<string>(
        //                    httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
        //                );

        //            var usuario = apiResult == "Ativo" ? true : false;

        //            ////Criptografa senha para guardar local já que a senha não é retornada. Melhor que seja assim.
        //            //var shield = new Shield(CryptProvider.Rijndael);
        //            //usuario.Senha = shield.Lock(obj.Senha);

        //            return usuario;
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(exception.Message);
        //    }
        //}

    }
}


