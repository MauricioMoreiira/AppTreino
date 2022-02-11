using Newtonsoft.Json;
using System;

namespace AppTreinoCarlos.Models
{
    public class Instrutor
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }

        [JsonProperty("dtInclui")]
        public DateTime DtInclui { get; set; }

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
        public int Ativo { get; set; }

        [JsonProperty("TOT_ATLETA")]
        public int TOT_ATLETA { get; set; }

        [JsonProperty("TOT_TREINO")]
        public int TOT_TREINO { get; set; }
    }
}