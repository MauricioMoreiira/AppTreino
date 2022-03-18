using AppTreinoCarlos.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AppTreinoCarlos.Pages
{
    public class ListAvaliacaoModel : PageModel
    {
        private static CommFunctions _model;
        public ListAvaliacaoModel(IConfiguration configuration)
        {
            _model = new CommFunctions(configuration);
        }
        public void OnGet(string TreinoID, string AtletaID, string InstrutorID)
        {
            ViewData["Avaliacoes"] = _model.GetAvaliacoesTreino(TreinoID, AtletaID);
            ViewData["Atleta"] = _model.GetAtletasCompletos(AtletaID, InstrutorID);
        }
    }
}
