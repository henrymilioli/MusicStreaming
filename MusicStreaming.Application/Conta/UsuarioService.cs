﻿using MusicStreaming.Application.Conta.Dto;
using MusicStreaming.Application.Conta;
using MusicStreaming.Core.Exception;
using MusicStreaming.Domain.Account.Aggregates;
using MusicStreaming.Domain.Streaming.Aggregates;
using MusicStreaming.Repository.Streaming;
using MusicStreaming.Repository.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStreaming.Application.Streaming;

namespace MusicStreaming.Application.Conta
{
    public class UsuarioService
    {
        private PlanoRepository planoRepository = new PlanoRepository();
        private UsuarioRepository usuarioRepository = new UsuarioRepository();
        private BandaService bandaService = new BandaService();

        public CriarUsuarioDTO CriarConta(CriarUsuarioDTO conta)
        {
            //Todo: Verificar pegar plano
            Plano plano = this.planoRepository.ObterPlanoPorId(conta.PlanoId);

            if (plano == null)
            {
                new BusinessException(new BusinessValidation()
                {
                    ErrorMessage = "Plano não encontrado",
                    ErrorName = nameof(CriarConta)
                }).ValidateAndThrow();
            }


            Cartao cartao = new Cartao();
            cartao.Ativo = conta.Cartao.Ativo;
            cartao.Numero = conta.Cartao.Numero;
            cartao.Limite = conta.Cartao.Limite;

            //Criar Usuario
            Usuario usuario = new Usuario();
            usuario.Criar(conta.Nome, conta.CPF, plano, cartao);

            //Gravar o usuario na base;
            this.usuarioRepository.SalvarUsuario(usuario);
            conta.Id = usuario.Id;

            // Retornar Conta Criada
            return conta;
        }

        public CriarUsuarioDTO ObterUsuario(Guid id)
        {
            var usuario = this.usuarioRepository.ObterUsuario(id);

            if (usuario == null)
                return null;

            CriarUsuarioDTO result = new CriarUsuarioDTO()
            {
                Id = usuario.Id,
                Cartao = new CartaoDto()
                {
                    Ativo = usuario.Cartoes.FirstOrDefault().Ativo,
                    Limite = usuario.Cartoes.FirstOrDefault().Limite,
                    Numero = "xxxx-xxxx-xxxx-xx"
                },
                CPF = usuario.CPF.NumeroFormatado(),
                Nome = usuario.Nome,
                Playlists = new List<PlaylistDto>()
            };

            foreach (var item in usuario.Playlists)
            {
                var playList = new PlaylistDto()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Publica = item.Publica,
                    Musicas = new List<Streaming.Dto.MusicaDto>()
                };

                foreach (var musicas in item.Musicas)
                {
                    playList.Musicas.Add(new Streaming.Dto.MusicaDto()
                    {
                        Duracao = musicas.Duracao.Valor,
                        Id = musicas.Id,
                        Nome = musicas.Nome
                    });
                }

                result.Playlists.Add(playList);
            }

            return result;
        }

        public void FavoritarMusica(Guid id, Guid idMusica)
        {
            var usuario = this.usuarioRepository.ObterUsuario(id);

            if (usuario == null)
            {
                throw new BusinessException(new BusinessValidation()
                {
                    ErrorMessage = "Não encontrei o usuário",
                    ErrorName = nameof(FavoritarMusica)
                });
            }

            var musica = this.bandaService.ObterMusica(idMusica);

            if (musica == null)
            {
                throw new BusinessException(new BusinessValidation()
                {
                    ErrorMessage = "Não encontrei a musica",
                    ErrorName = nameof(FavoritarMusica)
                });
            }

            usuario.Favoritar(musica);
            this.usuarioRepository.Update(usuario);

        }


    }
}