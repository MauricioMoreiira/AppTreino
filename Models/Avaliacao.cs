using Newtonsoft.Json;

namespace AppTreinoCarlos.Models
{
    public class Avaliacao
    {
        [JsonProperty("TI_ID")]
        public string TI_ID { get; set; }

        [JsonProperty("ATLETA_ID")]
        public string ATLETA_ID { get; set; }

        [JsonProperty("NOME")]
        public string NOME { get; set; }

        [JsonProperty("NOTA")]
        public string NOTA { get; set; }

        [JsonProperty("OBS")]
        public string OBS { get; set; }

        [JsonProperty("AVALIACAO_ID")]
        public string AVALIACAO_ID { get; set; }
    }
}
