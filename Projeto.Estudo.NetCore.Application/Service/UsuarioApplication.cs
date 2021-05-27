using Projeto.Estudo.NetCore.Domain.DTO;
using Projeto.Estudo.NetCore.Domain.Entities;
using Projeto.Estudo.NetCore.Domain.Exceptions;
using Projeto.Estudo.NetCore.Domain.Interfaces.Application;
using Projeto.Estudo.NetCore.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.NetCore.Application.Service
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioApplication(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task AddAsync(UsuarioDto usuario)
        {
            if (usuario == null)
            {
                throw new InvalidRequestException("Invalid request!");
            }

            var usuarioEntitie = new Usuario
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Phone = usuario.Phone
            };

            await _usuarioRepository.AddAsync(usuarioEntitie);
        }

        public async Task DeleteAsync(int id)
        {
            if(id <= 0)
            {
                throw new InvalidRequestException("Invalid request!");
            }

            await _usuarioRepository.DeleteAsync(id);
        }

        public async Task<UsuarioDto> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidRequestException("Invalid request!");
            }

            var usuario = await _usuarioRepository.GetAsync(id);
            return new UsuarioDto()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Phone = usuario.Phone
            };
        }

        public async Task UpdateAsync(UsuarioDto usuario)
        {
            if (usuario == null)
            {
                throw new InvalidRequestException("Invalid request!");
            }

            var usuarioEntitie = new Usuario
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Phone = usuario.Phone
            };
            await _usuarioRepository.UpdateAsync(usuarioEntitie);
        }
    }
}
