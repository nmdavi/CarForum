using CarForum.Models;
using CarForum.Models.Config;
using Microsoft.Owin.Security.OAuth;
using NHibernate;
using NHibernate.Util;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarForum
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        private static readonly ISessionFactory sessionFactory = NHibernateHelper.GetSessionFactory();
        private readonly ISession session = sessionFactory.OpenSession();

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                string username = context.UserName;
                string password = context.Password;

                Member user = session.Query<Member>().First(x => x.Username == username || x.Email == username && x.Password == password);

                if (user != null)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim("UserID", user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.StandardTitle)
                    };
                    ClaimsIdentity OAuthIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new Microsoft.Owin.Security.AuthenticationTicket(OAuthIdentity, new Microsoft.Owin.Security.AuthenticationProperties() { }));
                }
                else
                {
                    context.SetError("erro", "erro");
                }
            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}