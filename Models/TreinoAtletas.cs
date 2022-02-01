using Newtonsoft.Json;

namespace AppTreinoCarlos.Models
{
    public class TreinoAtletas
    {
        [JsonProperty("TA_ID")]
        public string TA_ID { get; set; }

        [JsonProperty("ATLETA_ID")]
        public string ATLETA_ID { get; set; }

        [JsonProperty("NOME")]
        public string NOME { get; set; }

        [JsonProperty("QTDE_AVALIACOES")]
        public string QTDE_AVALIACOES { get; set; }

        [JsonProperty("TREINO_ID")]
        public string TREINO_ID { get; set; }
    }
}
