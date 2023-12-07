using System;
using MusicStreaming.Domain.Account.Aggregates;
using MusicStreaming.Application.Conta.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MusicStreaming.Application.Conta.Dto
{
    public class CriarUsuarioDTO
    {
        public Guid Id { get; set; }
        
        [Required]         
        public String Nome {  get; set; }
        [Required]
        public String CPF {  get; set; }
        [Required]
        public Guid PlanoId  { get; set; }
        
        public CartaoDto Cartao { get; set; }
        public List<PlaylistDto> Playlists { get; set; }

    }

    public class CartaoDto
    {
        [Required]
        public String Numero { get; set; }
        [Required]
        public Decimal Limite { get; set; }
        [Required]
        public Boolean Ativo { get; set; }
    }

    public class PlaylistDto
    {
        public Guid Id { get; set; }

        public String Nome { get; set; }
        public Boolean Publica { get; set; }

        public List<MusicaDto> Musicas { get; set; }
    }

    public class MusicaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }

    }

}

