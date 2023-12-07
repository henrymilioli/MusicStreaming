using System;
using System.Collections.Generic;
using MusicStreaming.Application.Conta;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.Tests.Application.Conta
{
    public class UsuarioServiceTest
    {
public void DeveCriarUsuario()
        {
            // Arrange
            var usuario = new CriarUsuarioDTO();
            var usuarioService = new UsuarioService();
            // Act
            var novoUsuario = usuarioService.Criar(usuario);
            // Assert
            Assert.NotNull(novoUsuario);
        }
    }
}
