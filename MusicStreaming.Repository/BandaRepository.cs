using MusicStreaming.Domain.Account.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicStreaming.Repository
{
    public class BandaRepository
    {
        private HttpClient HttpClient { get; set; }

        public BandaRepository()
        {
            this.HttpClient = new HttpClient();
        }

        public async Task<Musica> ObterMusica(Guid id)
        {
            var result = await this.HttpClient.GetAsync($"https://localhost:7061/api/banda/musica/{id}");

            if (result.IsSuccessStatusCode == false)
                return null;

            var content = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Musica>(content);

        }

    }
}
