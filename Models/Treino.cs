using Newtonsoft.Json;
using System;

namespace AppTreinoCarlos.Models
{
    public class Treino
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("dtInicio")]
        public DateTime DtInicio { get; set; }

        [JsonProperty("dtFim")]
        public DateTime DtFim { get; set; }

        [JsonProperty("tipoEvento")]
        public int TipoEvento { get; set; }

        [JsonProperty("dtInclui")]
        public DateTime DtInclui { get; set; }

        [JsonProperty("TREINO_INSTRUTOR_ID")]
        public int TREINO_INSTRUTOR_ID { get; set; }

        [JsonProperty("QTDE_ATLETA")]
        public int QTDE_ATLETA { get; set; }

    }
}
