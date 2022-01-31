using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTreinoCarlos.Services
{
    public class AppConfigs
    {
        public string _NomeEmpresa { get; set; }
        public string _TokenBackend { get; set; }
        public string _BaseUrl { get; set; }
        public string _VersaoApp { get; set; }
        public string _NomeDoApp { get; set; }


        private readonly IConfiguration _configuration;

        public AppConfigs(IConfiguration configuration)
        {
            _configuration = configuration;
            _NomeEmpresa = _configuration["AppConfigs:NomeEmpresa"];
            _TokenBackend = _configuration["AppConfigs:TokenBackend"];
            _BaseUrl = _configuration["AppConfigs:BaseUrl"];
            _VersaoApp = _configuration["AppConfigs:VersaoApp"];
            _NomeDoApp = _configuration["AppConfigs:NomeDoAPP"];
        }

        public AppConfigs()
        {


        }
    }
}
