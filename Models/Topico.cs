using Newtonsoft.Json;

namespace AppTreinoCarlos.Models
{
    public class Topico
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("instrutorId")]
        public int instrutorId { get; set; }

        [JsonProperty("descricao")]
        public string descricao { get; set; }

        [JsonProperty("ativo")]
        public int ativo { get; set; }

        [JsonProperty("tipo")]
        public int tipo { get; set; }
    }
}