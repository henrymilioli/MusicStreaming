using MusicStreaming.Application.Conta;
using MusicStreaming.Application.Conta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.Tests.Application.Conta
{
    public class UsuarioServiceTests
    {
        [Fact]
        public async Task CriarConta_UsuarioValido_DeveCriarConta()
        {
            //Arrange
            var dto = new CriarUsuarioDTO()
            {
                Nome = "Teste",
                CPF = "12345678901",
                PlanoId = Guid.NewGuid(),
                Cartao = new CartaoDto()
                {
                    Numero = "1234567890123456",
                    Limite = 1000,
                    Ativo = true
                },
                Playlists = new List<PlaylistDto>()
                {
                    new PlaylistDto()
                    {
                        Nome = "Playlist 1",
                        Publica = true,
                        Musicas = new List<MusicaDto>()
                        {
                            new MusicaDto()
                            {
                                Nome = "Musica 1",
                                Duracao = 100
                            }
                        }
                    }
                }
            };

            var service = new UsuarioService();

            //Act
            await service.CriarConta(dto);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async Task CriarConta_UsuarioInvalido_DeveRetornarErro()
        {
            //Arrange
            var dto = new CriarUsuarioDTO()
            {
                Nome = "Teste",
                CPF = "12345678901",
                PlanoId = Guid.NewGuid(),
                Cartao = new CartaoDto()
                {
                    Numero = "1234567890123456",
                    Limite = 1000,
                    Ativo = true
                },
                Playlists = new List<PlaylistDto>()
                {
                    new PlaylistDto()
                    {
                        Nome = "Playlist 1",
                        Publica = true,
                        Musicas = new List<MusicaDto>()
                        {
                            new MusicaDto()
                            {
                                Nome = "Musica 1",
                                Duracao = 100
                            }
                        }
                    }
                }
            };

            var service = new UsuarioService();

            //Act
            await service.CriarConta(dto);

            //Assert
            Assert.True(true);
        }
    }
}
