using AppTreinoCarlos.Models;
using AppTreinoCarlos.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace AppTreinoCarlos.Pages
{
    public class ViewCardModel : PageModel
    {
        private static CommFunctions _model;
        public ViewCardModel(IConfiguration configuration)
        {
            _model = new CommFunctions(configuration);
        }

        public void OnGet(string atletaID, string treinoID, string instrutorID, string nota)
        {
            Atleta atleta = _model.GetAtletasCompletos(atletaID, instrutorID).FirstOrDefault<Atleta>();
            Treino treino = _model.GetTreino(treinoID, instrutorID).FirstOrDefault<Treino>();
            Instrutor instrutor = _model.GetInstrutor(instrutorID);

            ViewData["atleta"] = atleta;
            ViewData["treino"] = treino;
            ViewData["instrutor"] = instrutor;
            ViewData["nota"] = nota;
        }
    }
}
