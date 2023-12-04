﻿using MusicStreaming.Domain.Account.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.Repository.Conta
{
    public class UsuarioRepository
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        public void SalvarUsuario(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            UsuarioRepository.usuarios.Add(usuario);
        }
    }
}