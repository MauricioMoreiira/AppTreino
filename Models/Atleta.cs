using Newtonsoft.Json;
using System;

namespace AppTreinoCarlos.Models
{
    public class Atleta
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nivel")]
        public int Nivel { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("ativo")]
        public int Ativo { get; set; }

        [JsonProperty("dtInclui")]
        public DateTime DtInclui { get; set; }

        [JsonProperty("dtExpira")]
        public DateTime DtExpira { get; set; }

        [JsonProperty("foto")]
        public string Foto { get; set; }

        [JsonProperty("instrutorId")]
        public int InstrutorId { get; set; }

        [JsonProperty("MED_NOTA")]
        public Decimal MED_NOTA { get; set; }

        [JsonProperty("MAX_NOTA")]
        public int MAX_NOTA { get; set; }

        [JsonProperty("QTDE_AVALIACOES")]
        public int QTDE_AVALIACOES { get; set; }
    }
}
