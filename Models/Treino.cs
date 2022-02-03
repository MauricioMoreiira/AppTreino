﻿using Newtonsoft.Json;
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
    }
}
