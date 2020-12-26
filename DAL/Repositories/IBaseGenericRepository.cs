using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IGenericRepository<T>
    {
        void Create(T model);
        void Update(T model);
        void Delete(T model);
        T GetById(int modelId);
        IEnumerable<T> GetAll();
    }
}
