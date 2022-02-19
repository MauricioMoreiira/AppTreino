using Newtonsoft.Json;
using System;

namespace AppTreinoCarlos.Models
{
    public class Avaliacao
    {
        [JsonProperty("TREINO_INSTRUTOR_ID")]
        public int TREINO_INSTRUTOR_ID { get; set; }

        [JsonProperty("ATLETA_ID")]
        public int ATLETA_ID { get; set; }

        [JsonProperty("NOME")]
        public string Nome { get; set; }

        [JsonProperty("NOTA")]
        public int NOTA { get; set; }

        [JsonProperty("OBS")]
        public string Obs { get; set; }

        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("TREINO_ID")]
        public int TREINO_ID { get; set; }

        [JsonProperty("TOPICO_ID")]
        public int TOPICO_ID { get; set; }

        [JsonProperty("TOPICO_DESCRICAO")]
        public string TOPICO_DESCRICAO { get; set; }

        [JsonProperty("DT_INCLUI")]
        public DateTime DT_INCLUI { get; set; }

    }
}
