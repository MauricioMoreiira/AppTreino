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
    public class EditAvaliacaoModel : PageModel
    {
        private static CommFunctions _model;
        public EditAvaliacaoModel(IConfiguration configuration)
        {
            _model = new CommFunctions(configuration);
        }
        public void OnGet(string idTreino, string idAtleta, string NomeAtleta)
        {
            ViewData["Avaliacoes"] = _model.GetAvaliacoesTreino(idTreino, idAtleta);
            ViewData["Atleta"] = NomeAtleta ?? "";
        }
    }
}
