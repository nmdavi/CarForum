using FluentNHibernate.Mapping;

namespace CarForum.Models.Map
{
    public class MemberMap : ClassMap<Member>
    {
        public MemberMap()
        {
            Id(x => x.Id);

            Map(x => x.Username).Length(25).Not.Nullable();
            Map(x => x.Email).Length(254).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
            Map(x => x.UserImage).Length(60).Not.Nullable();
            Map(x => x.StandardTitle).Length(25).Not.Nullable();
            Map(x => x.CustomTitle).Length(25).Not.Nullable();
            Map(x => x.Signature).Nullable();
            Map(x => x.RegistrationDate).Not.Nullable().CustomSqlType("smalldatetime");
            Map(x => x.LastLogin).CustomSqlType("smalldatetime");
            Map(x => x.CurrentLogin).CustomSqlType("smalldatetime");
            Map(x => x.Active).Not.Nullable();
            Map(x => x.Online).Not.Nullable();

            HasMany(x => x.MemberThreads);
            HasMany(x => x.MemberReplies);
        }
    }
}