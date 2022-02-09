using AppTreinoCarlos.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AppTreinoCarlos.Pages
{
    public class TreinoModel : PageModel
    {
        private static CommFunctions _model;
        public TreinoModel(IConfiguration configuration)
        {
            _model = new CommFunctions(configuration);
        }

        public void OnGet(string idTreino, string idInstrutor)
        {
            ViewData["Treino"] = _model.GetTreino(idTreino, idInstrutor);
            ViewData["idInstrutor"] = idInstrutor;

        }
    }
}
