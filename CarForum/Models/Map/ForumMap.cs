using FluentNHibernate.Mapping;

namespace CarForum.Models.Map
{
    public class ForumMap : ClassMap<Forum>
    {
        public ForumMap()
        {
            Id(x => x.Id);

            Map(x => x.ForumTitle).Length(30).Not.Nullable();
            Map(x => x.ForumDesc).Length(100).Not.Nullable();

            References(x => x.ForumSection).Not.Nullable();
            HasMany(x => x.ForumThreads);
        }
    }
}