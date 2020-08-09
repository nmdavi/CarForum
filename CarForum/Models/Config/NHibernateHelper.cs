using CarForum.Models.Map;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace CarForum.Models.Config
{
    public class NHibernateHelper
    {
        public static ISessionFactory GetSessionFactory()
        {
            FluentConfiguration configuration = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(x => x.FromConnectionStringWithKey("db_forum")))
            .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
            .Mappings(x => x.FluentMappings.AddFromAssemblyOf<ForumMap>());

            return configuration.BuildSessionFactory();
        }
    }
}