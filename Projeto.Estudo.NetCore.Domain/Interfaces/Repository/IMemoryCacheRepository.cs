using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.NetCore.Domain.Interfaces.Repository
{
    public interface IMemoryCacheRepository
    {
        Task<T> GetOrCreateAsync<T>(string itemId, Func<Task<T>> getItem);
        void Clean();
        void Remove<T>(string itemId);
    }
}
