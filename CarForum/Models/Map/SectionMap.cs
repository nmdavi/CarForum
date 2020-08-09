using FluentNHibernate.Mapping;

namespace CarForum.Models.Map
{
    public class SectionMap : ClassMap<Section>
    {
        public SectionMap()
        {
            Id(x => x.Id);
            Map(x => x.SectionTitle).Length(30).Not.Nullable();

            HasMany(x => x.SectionForums);
        }
    }
}