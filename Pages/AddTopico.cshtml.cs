using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppTreinoCarlos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AppTreinoCarlos.Pages
{
    public class AddTopicoModel : PageModel
    {
        private static CommFunctions _model;
        public AddTopicoModel(IConfiguration configuration)
        {
            _model = new CommFunctions(configuration);
        }
        public void OnGet(string idInstrutor)
        {
            //ViewData["Topicos"] = _model.GetTopicos(idInstrutor);

        }
    }
}
