using Newtonsoft.Json;

namespace AppTreinoCarlos.Models
{
    public class TreinoInstrutor
    {
        
        [JsonProperty("treinoID")]
        public string treinoID { get; set; }        

        [JsonProperty("instrutorID")]
        public string instrutorID { get; set; }
    }
}
