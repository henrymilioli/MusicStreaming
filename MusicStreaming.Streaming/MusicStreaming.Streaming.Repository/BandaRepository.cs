using System;
using System.Runtime.CompilerServices;
using MusicStreaming.Streaming.Domain.Aggregates;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.Streaming.Repository
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

        
