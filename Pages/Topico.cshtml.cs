using AppTreinoCarlos.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AppTreinoCarlos.Pages
{
    public class TopicoModel : PageModel
    {
        private static CommFunctions _model;
        public TopicoModel(IConfiguration configuration)
        {
            _model = new CommFunctions(configuration);
        }
        public void OnGet(string idInstrutor)
        {
            ViewData["Topicos"] = _model.GetTopicos(idInstrutor);
            ViewData["idInstrutor"] = idInstrutor;

        }
    }
}
