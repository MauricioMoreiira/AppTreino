using Newtonsoft.Json;

namespace AppTreinoCarlos.Models
{
    public class Treino
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("dtInicio")]
        public string DtInicio { get; set; }

        [JsonProperty("dtFim")]
        public string DtFim { get; set; }

        [JsonProperty("tipoEvento")]
        public string TipoEvento { get; set; }

        [JsonProperty("dtInclui")]
        public string DtInclui { get; set; }
    }
}
