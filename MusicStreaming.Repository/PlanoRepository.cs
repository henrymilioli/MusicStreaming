using System;
using MusicStreaming.Domain.Account.Aggregates;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;

namespace MusicStreaming.Repository
{
    public class PlanoRepository
    {
        private HttpClient HttpClient { get; set; }

        public PlanoRepository()
        {
            HttpClient = new HttpClient();
        }

        public async Task<Plano> ObterPlano(Guid id)
        {
            var result = await HttpClient.GetAsync($"https://localhost:7061/api/Plano/{id}");

            if (result.IsSuccessStatusCode == false)
                return null;

            var content = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Plano>(content);

        }
    }
}

