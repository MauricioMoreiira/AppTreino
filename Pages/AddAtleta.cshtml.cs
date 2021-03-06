using AppTreinoCarlos.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using AppTreinoCarlos.Models;

namespace AppTreinoCarlos.Pages
{
    public class AddAtletaModel : PageModel
    {
        private static CommFunctions _model;
        public AddAtletaModel(IConfiguration configuration)
        {
            _model = new CommFunctions(configuration);
        }
        public void OnGet(string idInstrutor, string nome, string nivel, string id)
        {
            ViewData["idInstrutor"] = idInstrutor;
            ViewData["nome"] = nome == null ? "" : nome;
            ViewData["nivel"] = nivel == null ? "0" : nivel;
            ViewData["id"] = id == null ? "0" : id;
            Atleta atleta = id == "0" ? new Atleta() : _model.GetAtletasCompletos(id, idInstrutor)[0];
            ViewData["atleta"] = atleta;
        }
    }
}