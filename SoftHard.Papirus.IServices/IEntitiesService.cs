using SoftHard.Papirus.Models;
using System.Collections.Generic;

namespace SoftHard.Papirus.IServices
{
    public interface IEntitiesService<TEntity, TKey>
        where TEntity : Base
        where TKey : struct
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TKey id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TKey id);
    }
}
