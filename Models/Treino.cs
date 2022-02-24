using Newtonsoft.Json;
using System;

namespace AppTreinoCarlos.Models
{
    public class Treino
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("descricao")]
        public string descricao { get; set; }

        [JsonProperty("dtInicio")]
        public DateTime dtInicio { get; set; }

        [JsonProperty("dtFim")]
        public DateTime dtFim { get; set; }

        [JsonProperty("tipoEvento")]
        public int tipoEvento { get; set; }

        [JsonProperty("dtInclui")]
        public DateTime dtInclui { get; set; }

        [JsonProperty("TREINO_INSTRUTOR_ID")]
        public int TREINO_INSTRUTOR_ID { get; set; }

        [JsonProperty("QTDE_ATLETA")]
        public int QTDE_ATLETA { get; set; }

    }
}
