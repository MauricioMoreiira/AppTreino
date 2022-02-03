using Newtonsoft.Json;

namespace AppTreinoCarlos.Models
{
    public class Topico
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("instrutorId")]
        public int InstrutorId { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("ativo")]
        public int Ativo { get; set; }

        [JsonProperty("tipo")]
        public int Tipo { get; set; }
    }
}