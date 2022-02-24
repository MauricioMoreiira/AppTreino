using Newtonsoft.Json;
using System;

namespace AppTreinoCarlos.Models
{
    public class Atleta
    {
        public Atleta()
        {
        }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("nivel")]
        public string nivel { get; set; }

        [JsonProperty("nome")]
        public string nome { get; set; }

        [JsonProperty("ativo")]
        public string ativo { get; set; }

        [JsonProperty("dtInclui")]
        public DateTime dtInclui { get; set; }

        [JsonProperty("dtExpira")]
        public DateTime dtExpira { get; set; }

        [JsonProperty("foto")]
        public string foto { get; set; }

        [JsonProperty("instrutorId")]
        public string instrutorId { get; set; }

        [JsonProperty("MED_NOTA")]
        public string MED_NOTA { get; set; }

        [JsonProperty("MAX_NOTA")]
        public string MAX_NOTA { get; set; }

        [JsonProperty("QTDE_AVALIACOES")]
        public string QTDE_AVALIACOES { get; set; }
    }
}
