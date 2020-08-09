using CarForum.Models.Config;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarForum.Models.Repository
{
    public class GenericRepository : IGenericRepository, IDisposable
    {
        private static readonly ISessionFactory sessionFactory = NHibernateHelper.GetSessionFactory();
        private readonly ISession session = sessionFactory.OpenSession();

        public object Create<T>(T entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                var created = session.Save(entity);

                transaction.Commit();

                return created;
            }
        }

        public void Delete<T>(int id)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                var entity = Get<T>(id);

                session.Delete(entity);
                transaction.Commit();
            }
        }

        public void Dispose()
        {
            session.Close();
            sessionFactory.Close();
        }

        public T Get<T>(int id)
        {
            return session.Get<T>(id);
        }

        public IEnumerable<T> GetAll<T>()
        {
            return session.Query<T>().ToList();
        }

        public void Update<T>(T entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(entity);
                transaction.Commit();
            }
        }
    }
}