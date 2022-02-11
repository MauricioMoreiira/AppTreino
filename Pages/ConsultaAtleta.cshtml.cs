using AppTreinoCarlos.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AppTreinoCarlos.Pages
{
    public class ConsultaTreinosModel : PageModel
    {
        private static CommFunctions _model;
        public ConsultaTreinosModel(IConfiguration configuration)
        {
            _model = new CommFunctions(configuration);
        }
        public void OnGet(string idAtleta, string idInstrutor)
        {
            ViewData["Atleta"] = _model.GetAtletasCompletos(idAtleta, idInstrutor);
        }
    }
}