using Newtonsoft.Json;

namespace AppTreinoCarlos.Models
{
    public class Topico
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("instrutorId")]
        public string InstrutorId { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("ativo")]
        public string Ativo { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }
    }
}