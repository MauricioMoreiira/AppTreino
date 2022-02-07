﻿using AppTreinoCarlos.Services;
using AppTreinoCarlos.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using static AppTreinoCarlos.Utils.AjaxMessage;

namespace AppTreino.Controllers
{
    public class HomeController : Controller
    {
        private static CommFunctions _model;

        public HomeController(IConfiguration configuration)
        {
            _model = new CommFunctions(configuration);
            //_validateToken = new ValidateToken(configuration);
        }


        public ActionResult Login([FromBody] string email, string senha)
        {
            try
            {
                var data = _model.Login(email, senha);
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Success,
                    Message = "Bem-vindo",
                    Title = "Sucesso",
                    EmbeddedData = data
                }));
            }
            catch (Exception exception)
            {
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Failure,
                    Message = exception.Message,
                    Title = "Erro de Sistema"
                }));
            }
        }


        public ActionResult GetAtletasCompletos([FromBody] string idAtleta, string idInstrutor)
        {
            try
            {
                var data = _model.GetAtletasCompletos(idAtleta, idInstrutor);
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Success,
                    Message = "Menu carregado com sucesso",
                    Title = "Sucesso",
                    EmbeddedData = data
                }));
            }
            catch (Exception exception)
            {
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Failure,
                    Message = exception.Message,
                    Title = "Erro de Sistema"
                }));
            }
        }

        public ActionResult GetAtletasTreino([FromBody] string idTreino)
        {
            try
            {
                var data = _model.GetAtletasTreino(idTreino);
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Success,
                    Message = "Menu carregado com sucesso",
                    Title = "Sucesso",
                    EmbeddedData = data
                }));
            }
            catch (Exception exception)
            {
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Failure,
                    Message = exception.Message,
                    Title = "Erro de Sistema"
                }));
            }
        }

        public ActionResult GetAvaliacoesTreino([FromBody] string idTreino, string idAtleta)
        {
            try
            {
                var data = _model.GetAvaliacoesTreino(idTreino, idAtleta);
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Success,
                    Message = "Menu carregado com sucesso",
                    Title = "Sucesso",
                    EmbeddedData = data
                }));
            }
            catch (Exception exception)
            {
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Failure,
                    Message = exception.Message,
                    Title = "Erro de Sistema"
                }));
            }
        }

        public ActionResult GetTreino([FromBody] string idTreino, string idInstrutor)
        {
            try
            {
                var data = _model.GetTreino(idTreino, idInstrutor);
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Success,
                    Message = "Menu carregado com sucesso",
                    Title = "Sucesso",
                    EmbeddedData = data
                }));
            }
            catch (Exception exception)
            {
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Failure,
                    Message = exception.Message,
                    Title = "Erro de Sistema"
                }));
            }
        }

        public ActionResult DelTreinoAtleta([FromBody] string treinoID, string atletaID)
        {
            try
            {
                var data = _model.GetTreino(treinoID, atletaID);
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Success,
                    Message = "Menu carregado com sucesso",
                    Title = "Sucesso",
                    EmbeddedData = data
                }));
            }
            catch (Exception exception)
            {
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Failure,
                    Message = exception.Message,
                    Title = "Erro de Sistema"
                }));
            }
        }

        public bool SetAvaliacao(dynamic obj)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = BuildCall(httpClient, "SET_AVALIACAO");
                    var apiResult =
                        JsonConvert.DeserializeObject<bool>(
                            httpClient.PostAsync(url.ToString(),
                            new StringContent(JsonConvert.SerializeObject(obj),
                            Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
                        );
                    return apiResult;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private object BuildCall(HttpClient httpClient, string v)
        {
            throw new NotImplementedException();
        }









        //public ActionResult UsuarioAtivo([FromBody] Credential obj)
        //{
        //    try
        //    {
        //        var data = _model.UsuarioAtivo(obj);
        //        return Json(AjaxMessage.Create(new MessageContent
        //        {
        //            MessageType = MessageType.Success,
        //            Message = "Bem-vindo",
        //            Title = "Sucesso",
        //            EmbeddedData = data
        //        }));
        //    }
        //    catch (Exception exception)
        //    {
        //        return Json(AjaxMessage.Create(new MessageContent
        //        {
        //            MessageType = MessageType.Failure,
        //            Message = exception.Message,
        //            Title = "Erro de Sistema"
        //        }));
        //    }
        //}
    }
}
