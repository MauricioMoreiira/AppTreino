using AppTreinoCarlos.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AppTreinoCarlos.Pages
{
    public class EditTreinoModel : PageModel
    {
        private static CommFunctions _model;
        public EditTreinoModel(IConfiguration configuration)
        {
            _model = new CommFunctions(configuration);
        }
        public void OnGet(string idTreino, string desc, string dtInicio, string tipo, string treinoInstrutorId)
        {       
            ViewData["idTreino"] = idTreino;

            ViewData["descricao"] = desc;
            string t0 = dtInicio.Substring(6, 4) + "-" + dtInicio.Substring(3, 2) + "-" + dtInicio.Substring(0, 2);
            ViewData["dtInicio"] = t0;
            ViewData["dtFim"] = t0;
            ViewData["tipoEvento"] = tipo;
            ViewData["TREINO_INSTRUTOR_ID"] = treinoInstrutorId;
        }
    }
}
