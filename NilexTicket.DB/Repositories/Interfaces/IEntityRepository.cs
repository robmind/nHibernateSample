using System.Collections.Generic;

namespace NilexTicket.DB.Repositories.Interfaces
{
    public interface IEntityRepository<T> where T : class, IEntity
    {
        T Create();
        T Load(int id);
        void Save(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
    }
}