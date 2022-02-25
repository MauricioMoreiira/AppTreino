using AppTreinoCarlos.Models;
using AppTreinoCarlos.Services;
using AppTreinoCarlos.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        public ActionResult DelTreinoAtleta([FromBody] dynamic obj)
        {
            try
            {
                dynamic o = JsonConvert.DeserializeObject<dynamic>(obj.ToString());
                string treino_id = o["treinoID"];
                string ATLETA_ID = o["atletaID"];

                var data = _model.DelTreinoAtleta(treino_id, ATLETA_ID);
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Success,
                    Message = "Atleta removido com sucesso",
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
        public ActionResult SetAvaliacao([FromBody] dynamic obj)
        {
            try
            {
                Avaliacao avaliacao = JsonConvert.DeserializeObject<Avaliacao>(obj.ToString());



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
                    Message = "Inativado com sucesso",
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

        public ActionResult InativaTreino([FromBody] string treinoId)
        {
            try
            {
                var data = _model.inativaTreino(treinoId);
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Success,
                    Message = "Inativado com sucesso",
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
                Atleta atleta = JsonConvert.DeserializeObject<Atleta>(obj.ToString());
                var data = _model.SetAtleta(atleta);
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

        public ActionResult SetTreino([FromBody] dynamic obj)
        {
            try
            {
                dynamic o = JsonConvert.DeserializeObject<dynamic>(obj.ToString());
                Treino treino = JsonConvert.DeserializeObject<Treino>(obj.ToString());

                //Treino treino = new Treino();
                //treino.descricao = o["descricao"];
                //treino.dtFim = o["dataIni"];
                //treino.dtInicio = o["dataIni"];
                //treino.id = o["idTreino"];
                //treino.tipoEvento = o["tipoEvento"];

                var data0 = _model.SetTreino(treino);

                TreinoInstrutor setInstrutor = new TreinoInstrutor();
                setInstrutor.treinoID = data0;
                setInstrutor.instrutorID = o["idInstrutor"];
                //string treinoID = obj["treinoID"];
                //string instrutorID = obj["instrutorID"];

                var data1 = _model.SetTreinoInstrutor(setInstrutor);
                if (data1 == true)
                {
                    foreach (int a in o["atletas"])
                    {
                        if (int.Parse(_model.SetTreinoAtleta(data0.ToString(), a.ToString())) == 0)
                        {
                            throw new Exception("Não foi possivel adicionar atleta.");
                        }
                    }
                }
                else
                {
                    throw new Exception("Não foi possivel adicionar instrutor.");
                }

                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Success,
                    Message = "Enviado com sucesso",
                    Title = "Sucesso",
                    EmbeddedData = null
                }));
            }
            catch (Exception exception)
            {
                //TODO deletar treino
                //TODO deletar settreino instrutor
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Failure,
                    Message = exception.Message,
                    Title = "Erro de Sistema"
                }));
            }
        }

        public ActionResult SetTopico([FromBody] dynamic obj)
        {
            try
            {
                Topico topico = JsonConvert.DeserializeObject<Topico>(obj.ToString());

                var data = _model.SetTopicos(topico);
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

        public ActionResult SetTreinoOnly([FromBody] dynamic obj)
        {
            try
            {
                Treino treino = JsonConvert.DeserializeObject<Treino>(obj.ToString());
                var data = _model.SetTreino(treino);
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

        public ActionResult DelAvaliacao([FromBody] dynamic obj)
        {
            try
            {
                dynamic o = JsonConvert.DeserializeObject<dynamic>(obj.ToString());
                string ID = o["ID"];
                string treinoID = o["treinoID"];
                var data = _model.DelAvaliacao(treinoID, ID);
                return Json(AjaxMessage.Create(new MessageContent
                {
                    MessageType = MessageType.Success,
                    Message = "Excluido com sucesso",
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
