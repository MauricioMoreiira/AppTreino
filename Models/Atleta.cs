using Newtonsoft.Json;

namespace AppTreinoCarlos.Models
{
    public class Atleta
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nivel")]
        public string Nivel { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("ativo")]
        public string Ativo { get; set; }

        [JsonProperty("dtInclui")]
        public string DtInclui { get; set; }

        [JsonProperty("dtExpira")]
        public string DtExpira { get; set; }

        [JsonProperty("foto")]
        public string Foto { get; set; }

        [JsonProperty("instrutorId")]
        public string InstrutorId { get; set; }
    }
}
