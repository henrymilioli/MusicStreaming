﻿using System;
using System.Collections.Generic;
using MusicStreaming.Domain.Account.Aggregates;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.Domain.Account.Aggregates
{
    public class Plano
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
        
        public string Descricao { get; set; }
        
        public Decimal Valor { get; set; }

    }
}
