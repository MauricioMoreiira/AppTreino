using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppTreinoCarlos.Models;
using AppTreinoCarlos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AppTreinoCarlos.Pages
{
    public class AvaliacoesModel : PageModel
    {
        private static CommFunctions _model;
        public AvaliacoesModel(IConfiguration configuration)
        {
            _model = new CommFunctions(configuration);
        }

        public void OnGet(string TREINO_INSTRUTOR_ID, string ATLETA_ID, string NOME, string TREINO_ID, string idInstrutor)
        {
            List<Topico> Lst = _model.GetTopicos(idInstrutor);
            ViewData["TopicoAtaque"] = Lst.Where(x => x.Tipo == 1).ToList<Topico>();
            ViewData["TopicoDefesa"] = Lst.Where(x => x.Tipo == 0).ToList<Topico>();

            ViewData["TREINO_INSTRUTOR_ID"] = TREINO_INSTRUTOR_ID;
            ViewData["ATLETA_ID"] = ATLETA_ID;
            ViewData["NOME"] = NOME;
            ViewData["TREINO_ID"] = TREINO_ID;
        }
    }
}
