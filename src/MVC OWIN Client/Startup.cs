using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

[assembly: OwinStartup(typeof(MVC_OWIN_Client.Startup))]
namespace MVC_OWIN_Client
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "client",
                ClientSecret="secret",
                Authority = "http://localhost:5000/",
                RedirectUri = "https://localhost:44301/",

                Scope = "openid api1",
                RequireHttpsMetadata=false,
                UseTokenLifetime = false,
                SignInAsAuthenticationType = "Cookies",
            });
        }
    }
}