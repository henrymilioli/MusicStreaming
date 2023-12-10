using System;
using MusicStreaming.Streaming.Domain.ValueObject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.Streaming.Domain.Aggregates
{
    public class Musica
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Duracao Duracao { get; set; }

        public Album Album { get; set; }

    }
}
