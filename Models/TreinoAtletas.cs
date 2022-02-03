using Newtonsoft.Json;

namespace AppTreinoCarlos.Models
{
    public class TreinoAtletas
    {
        [JsonProperty("TA_ID")]
        public string TA_ID { get; set; }

        [JsonProperty("ATLETA_ID")]
        public string AtletaId { get; set; }

        [JsonProperty("NOME")]             
        public string Nome { get; set; }

        [JsonProperty("QTDE_AVALIACOES")]
        public string QtdeAvaliacoes { get; set; }

        [JsonProperty("TREINO_ID")]
        public string TreinoId { get; set; }
    }
}
