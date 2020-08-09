using FluentNHibernate.Mapping;

namespace CarForum.Models.Map
{
    public class ThreadMap : ClassMap<Thread>
    {
        public ThreadMap()
        {
            Id(x => x.Id);

            Map(x => x.Title).Length(100).Not.Nullable();
            Map(x => x.CreationDate).Not.Nullable().CustomSqlType(SqlType.SmallDateTime);
            Map(x => x.Views).Not.Nullable();
            Map(x => x.Text).Not.Nullable().CustomSqlType(SqlType.LargeText);

            References(x => x.ThreadCreator).Not.Nullable();
            References(x => x.ThreadForum).Not.Nullable();
            HasMany(x => x.ThreadReplies);
        }
    }
}