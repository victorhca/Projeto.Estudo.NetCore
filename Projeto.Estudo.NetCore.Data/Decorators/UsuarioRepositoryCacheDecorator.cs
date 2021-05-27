using Microsoft.Extensions.Caching.Distributed;
using Projeto.Estudo.NetCore.Domain.Entities;
using Projeto.Estudo.NetCore.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.NetCore.Data.Decorators
{
    public class UsuarioRepositoryCacheDecorator : IUsuarioRepository
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMemoryCacheRepository _cache;

        public UsuarioRepositoryCacheDecorator(IUsuarioRepository usuarioRepository, IMemoryCacheRepository cache)
        {
            _usuarioRepository = usuarioRepository;
            _cache = cache;
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task DeleteAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }

        public async Task<Usuario> GetAsync(int id)
        {
            return await _cache.GetOrCreateAsync(id.ToString(), () => _usuarioRepository.GetAsync(id));
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            await _usuarioRepository.UpdateAsync(usuario);
        }
    }
}
