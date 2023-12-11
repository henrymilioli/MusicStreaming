using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicStreaming.Streaming.Application.Dto
{
    public class PlanoDto
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }
        [JsonPropertyName("Nome")]
        public String Nome { get; set; }
        [JsonPropertyName("Descricao")]
        public String Descricao { get; set; }
        [JsonPropertyName("Valor")]
        public Decimal Valor { get; set; }
    }
}
