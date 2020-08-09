using FluentNHibernate.Mapping;

namespace CarForum.Models.Map
{
    public class ReplyMap : ClassMap<Reply>
    {
        public ReplyMap()
        {
            Id(x => x.Id);
            Map(x => x.CreationDate).Not.Nullable().CustomSqlType(SqlType.SmallDateTime);
            Map(x => x.ReplyText).Not.Nullable().CustomSqlType(SqlType.LargeText);

            References(x => x.ReplyCreator).Not.Nullable();
            References(x => x.ReplyThread).Not.Nullable();
        }
    }
}