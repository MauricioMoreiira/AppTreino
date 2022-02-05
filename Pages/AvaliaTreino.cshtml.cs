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
    public class AvaliaTreinoModel : PageModel
    {
        private static CommFunctions _model;
        public AvaliaTreinoModel(IConfiguration configuration)
        {
            _model = new CommFunctions(configuration);
        }

        public void OnGet(string idTreino, string  idTreinoInstrutor, string idInstrutor)
        {
            ViewData["Avaliacoes"] = _model.GetAtletasTreino(idTreino);
            ViewData["idTreinoInstrutor"] = idTreinoInstrutor;


          List <Topico> Lst = _model.GetTopicos(idInstrutor);
            ViewData["TopicoAtaque"] = Lst.Where(x => x.Tipo == 1).Select(s => s.Descricao).ToList<string>();
            ViewData["TopicoDefesa"] = Lst.Where(x => x.Tipo == 0).ToList<Topico>();

        }
    }
}
