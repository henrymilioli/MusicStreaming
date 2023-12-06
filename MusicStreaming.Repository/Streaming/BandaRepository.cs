using MusicStreaming.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.Repository.Streaming
{
    public class BandaRepository
    {
        private static List<Banda> Bandas = new List<Banda>();

        public void Criar(Banda banda)
        {
            banda.Id = Guid.NewGuid();
            Bandas.Add(banda);
        }

        public Banda ObterBanda(Guid id)
        {
            return Bandas.FirstOrDefault(x => x.Id == id);
        }

        public Musica ObterMusica(Guid idMusica)
        {
            Musica result = null;

            foreach (var banda in Bandas)
            {
                foreach (var album in banda.Albums)
                {
                    result = album.Musicas.FirstOrDefault(x => x.Id == idMusica);

                    if (result != null)
                        break;
                }
            }

            return result;

        }
    }
}
