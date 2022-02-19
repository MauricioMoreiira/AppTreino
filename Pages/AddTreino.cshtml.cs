using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppTreinoCarlos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AppTreinoCarlos.Pages
{
    public class AddTreinoModel : PageModel
    {
        private static CommFunctions _model;
        public AddTreinoModel(IConfiguration configuration)
        {
            _model = new CommFunctions(configuration);
        }
        public void OnGet(string idTreino, string idInstrutor)
        {

            ViewData["Atletas"] = _model.GetAtletasCompletos("0", idInstrutor);
            ViewData["idTreino"] = idTreino;
            //ViewData["Treino1"] = _model.GetTreino(idTreino, idInstrutor);
            //ViewData["idInstrutor1"] = idInstrutor;
        }
    }
}
