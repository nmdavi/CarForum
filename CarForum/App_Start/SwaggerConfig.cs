using CarForum;
using Swashbuckle.Application;
using System.Web.Http;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CarForum
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "CarForum")
                    .Description("Welcome to the CarForum API, get your token at http://localhost:56956/api/token")
                    .Contact(cc => cc
                    .Name("Davi Mendonça")
                    .Url("https://github.com/NMDavi")
                    .Email("davimendonca@protonmail.com"));

                    c.ApiKey("Authorization")
                    .Description("Filling bearer token here")
                    .Name("Bearer")
                    .In("header");
                })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle("CarForum");
                    c.EnableApiKeySupport("Authorization", "header");
                });
        }
    }
}