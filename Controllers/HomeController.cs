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
                Atleta atleta = JsonConvert.DeserializeObject<Atleta>(obj.ToString());
                //Atleta atleta = new Atleta();
                //atleta.Ativo = obj["ativo"];
                //atleta.DtExpira = obj["dtExpira"];
                //atleta.DtInclui = obj["dtInclui"];
                //atleta.Foto = obj["foto"];
                //atleta.Id = obj["id"];
                //atleta.InstrutorId = obj["instrutorId"];
                //atleta.Nivel = obj["nivel"];
                //atleta.Nome = obj["nome"];
                //atleta.MAX_NOTA = "0";
                //atleta.MED_NOTA = "0";
                //atleta.QTDE_AVALIACOES = "0";

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
                //o.idTreino = @idTreino;
                //o.idInstrutor = @idInstrutor
                //o.descricao = _descricao;
                //o.dataIni = _dataIni;
                //o.dataFim = _dtFim;
                //o.tipoEvento = _tipoEvento;
                //var atletas = [];
                var o = JsonConvert.DeserializeObject<dynamic>(obj.ToString());

                Treino treino = new Treino();
                treino.Descricao = o["descricao"];
                treino.DtFim = o["dataIni"];
                treino.DtInicio = o["dataIni"];
                treino.Id = o["idTreino"];
                treino.TipoEvento = o["tipoEvento"];
                //string Descricao = dre["descricao"];
                //string DtFim = dre["dataIni"];
                //string DtInicio = dre["dataIni"];
                //string Id = dre["idTreino"];
                //string TipoEvento = dre["tipoEvento"];


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
                //var o = JsonConvert.DeserializeObject<dynamic>(obj.ToString());

                //Topico treino = new Topico();
                //treino.Descricao = o["descricao"];
                //treino.DtFim = o["dataIni"];
                //treino.DtInicio = o["dataIni"];
                //treino.Id = o["idTreino"];
                //treino.TipoEvento = o["tipoEvento"];

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

    }
}
