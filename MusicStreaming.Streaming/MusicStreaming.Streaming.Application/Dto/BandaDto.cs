﻿using System;
using MusicStreaming.Streaming.Domain.Aggregates;
using MusicStreaming.Streaming.Domain.ValueObject;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.Streaming.Application.Dto
{
    public class BandaDto
    {
        public Guid Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public String Descricao { get; set; }

        public List<AlbumDto> Albums { get; set; }


    }

    public class AlbumDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public List<MusicaDto> Musicas { get; set; }
    }

    public class MusicaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }

    }
}