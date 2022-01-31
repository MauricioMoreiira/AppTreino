using AppTreinoCarlos.Models;
using AppTreinoCarlos.Services;
using AppTreinoCarlos.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
                var data = _model.Login(obj);
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




        public ActionResult UsuarioAtivo([FromBody] Credential obj)
        {
            try
            {
                var data = _model.UsuarioAtivo(obj);
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



    }
}
