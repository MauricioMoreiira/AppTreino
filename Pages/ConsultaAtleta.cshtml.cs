using AppTreinoCarlos.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AppTreinoCarlos.Pages
{
    public class ConsultaAtletaModel : PageModel
    {
        private static CommFunctions _model;
        public ConsultaAtletaModel(IConfiguration configuration)
        {
            _model = new CommFunctions(configuration);
        }
        public void OnGet(string idAtleta, string idInstrutor)
        {
            ViewData["Atleta"] = _model.GetAtletasCompletos(idAtleta, idInstrutor);
        }
    }
}