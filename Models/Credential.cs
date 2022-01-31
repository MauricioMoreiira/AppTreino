using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace AppTreinoCarlos.Models
{
    public class Credential
    {
        [JsonProperty("senha")]
        public string Senha { get; set; }

        [JsonProperty("usuario")]
        public string Usuario { get; set; }
    }
}
