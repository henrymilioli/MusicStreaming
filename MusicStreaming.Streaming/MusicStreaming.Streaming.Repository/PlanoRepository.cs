using System;
using MusicStreaming.Streaming.Domain.Aggregates;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.Streaming.Repository
{
    public class PlanoRepository
    {
        private static List<Plano> plano;
        public PlanoRepository()
        {
            if (PlanoRepository.plano == null)
            {
                PlanoRepository.plano = new List<Plano>();
                PlanoRepository.plano.Add(new Plano()
                {
                    Descricao = "Plano Basico",
                    Nome = "Plano Low Quality",
                    Valor = 10,
                    Id = new Guid("8D044595-D4A6-4E1A-9F09-DAB92205C71C")
                });
            }
        }

        public Plano ObterPlanoPorId(Guid idPlano)
        {
            return PlanoRepository.plano.FirstOrDefault(x => x.Id == idPlano);
        }
    }
}
