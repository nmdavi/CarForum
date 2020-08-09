using System.Collections.Generic;

namespace CarForum.Models.Repository
{
    public interface IGenericRepository
    {
        object Create<T>(T entity);

        T Get<T>(int id);

        IEnumerable<T> GetAll<T>();

        void Update<T>(T entity);

        void Delete<T>(int id);
    }
}