using System;
using MusicStreaming.Domain.Streaming.Aggregates;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStreaming.Repository.Streaming;

namespace MusicStreaming.Repository.Streaming
{
    public class PlanoRepository
    {


        private static List<Plano> plano;

        public PlanoRepository()
        {

            if (PlanoRepository.plano == null)
            {
                PlanoRepository.plano = new List<Plano>();

                Plano planoBase = new Plano()
                {
                    Nome = "Plano Base",
                    Valor = 20M,
                    Id = new Guid("8D044595-D4A6-4E1A-9F09-DAB92205C71C")
                };

                PlanoRepository.plano.Add(planoBase);
            }
        }


        public Plano ObterPlanoPorId(Guid idPlano) => PlanoRepository.plano.FirstOrDefault(plano => plano.Id == idPlano);

    }
}

