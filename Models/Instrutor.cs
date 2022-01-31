using System.Collections.Generic;
using Newtonsoft.Json;

namespace AppTreinoCarlos.Models
{
    public class Instrutor
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }

        [JsonProperty("dtInclui")]
        public string DtInclui { get; set; }

        [JsonProperty("celular")]
        public string Celular { get; set; }


        [JsonProperty("whatsapp")]
        public string Whatsapp { get; set; }

        [JsonProperty("instagram")]
        public string Instagram { get; set; }

        [JsonProperty("facebook")]
        public string Facebook { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("ativo")]
        public string Ativo { get; set; }
    }
}
