using AppTreinoCarlos.Models;
using AppTreinoCarlos.Services;
using AppTreinoCarlos.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Dynamic;
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
        public ActionResult Login([FromBody] Credential obj)
        {
            try
            {
                var data = _model.Login(obj.Usuario, obj.Senha);
                if (data == null) { throw new Exception("Não Autorizado"); }
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
        public ActionResult SetAvaliacao([FromBody] Avaliacao avaliacao)
        {
            try
            {
                var data = _model.SetAvaliacao(avaliacao);
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Success,
                    Message = "Avaliação com sucesso",
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
        public ActionResult InativaAtleta([FromBody] string atletaId)
        {
            try
            {
                var data = _model.inativaAtleta(atletaId);
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Success,
                    Message = "Avaliação com sucesso",
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
        public ActionResult SetAtleta([FromBody] dynamic obj)
        {
            try
            {
                Atleta atleta = new Atleta();
                atleta.Ativo = obj["ativo"];
                atleta.DtExpira = obj["dtExpira"];
                atleta.DtInclui = obj["dtInclui"];
                atleta.Foto = obj["foto"];
                atleta.Id = obj["id"];
                atleta.InstrutorId = obj["instrutorId"];
                atleta.Nivel = obj["nivel"];
                atleta.Nome = obj["nome"];
                atleta.MAX_NOTA = "0";
                atleta.MED_NOTA = "0";
                atleta.QTDE_AVALIACOES = "0";
                
                var data = _model.SetAtleta(obj);
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Success,
                    Message = "Enviado com sucesso",
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


    }
}
