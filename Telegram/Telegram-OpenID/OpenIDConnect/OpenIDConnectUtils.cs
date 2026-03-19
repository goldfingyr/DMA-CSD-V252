using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


// Required NuGet Packages
// Microsoft.AspNetCore.Authentication.JwtBearer
// Microsoft.AspNetCore.Authentication.OpenIdConnect
// Microsoft.IdentityModel.Protocols.OpenIdConnect
// Microsoft.AspNet.WebApi.Core

namespace Telegram_OpenID.OpenIDConnect
{
    public class OpenIDConnectUtils
    {
        // Configuration priority from highest to lowest
        // Highest: Command line arguments
        //        : Non-prefixed environment variables
        //        : User secrets from the .NET User Secrets Manager
        //        : Any appsettings.{ ENVIRONMENT_NAME }.json files
        //        : The appsettings.json file
        // Lowest : Fallback to the host configuration

        /// <summary>
        /// Setting up OpenIDConnect authentication (Program.cs)
        /// </summary>
        /// <param name="builder">WebApplicationBuilder</param>

        public void ConfigureBuild(WebApplicationBuilder builder)
        {
            // Add services to the container.
            MyConfiguration.Set(builder.Configuration);
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                options.Authority = builder.Configuration["OpenIDRealmURI"];
                options.ClientId = builder.Configuration["OpenIDClient"];
                options.ClientSecret = builder.Configuration["OpenIDSecret"];
                options.CallbackPath = "/signin-oidc";

                // Authorization Code flow (recommended)
                options.ResponseType = "code";
                options.SaveTokens = true;                // store tokens in auth properties
                options.GetClaimsFromUserInfoEndpoint = true;
                options.MapInboundClaims = false;

                // Scopes - clear then add what's needed
                options.Scope.Clear();
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("ucn");
                options.Scope.Add("email");
                options.Scope.Add("offline_access"); // to get refresh tokens

                // Map claim types if needed
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    RoleClaimType = "roles", // 👈 IMPORTANT
                    NameClaimType = "name",
                    ValidateIssuer = true,
                    ValidateAudience = true
                };

                options.MapInboundClaims = false; // prevent automatic claim type mapping
                options.RequireHttpsMetadata = true; // set to false only for development

                // Optional: events for logging / error handling
                options.Events = new OpenIdConnectEvents
                {
                    OnTokenValidated = context =>
                    {
                        // e.g. add custom claims or logging
                        var loggerFactory = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>();
                        var logger = loggerFactory.CreateLogger("Api.Authorization");
                        var claims = context?.Principal?.Claims;
                        if (claims is null || !claims.Any())
                        {
                            logger.LogWarning("Claims null or empty");
                            return Task.CompletedTask;
                        }
                        var claimsBuilder = new StringBuilder();
                        claimsBuilder.AppendLine("User Claims:");
                        foreach (var claim in claims)
                        {
                            claimsBuilder.AppendLine($"[{claim.Type}] - [{claim.Value}]");
                        }
                        logger.LogTrace("{Claims}", claimsBuilder.ToString());
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        context.HandleResponse();
                        context.Response.Redirect("/Error?message=" + Uri.EscapeDataString(context.Exception.Message));
                        return Task.CompletedTask;
                    }
                };
            });
            // Change here for authorization policies
            builder.Services
                   .AddAuthorizationBuilder()
                   .AddPolicy("read_access", builder =>
                   {
                       // claim, list of acceptable values
                       builder.RequireClaim("myClaim", "MyClaimValueRO1", "MyClaimValueRO2");
                   })
                   .AddPolicy("write_access", builder =>
                   {
                       builder.RequireClaim("myClaim", "MyClaimValueRW1", "MyClaimValueRW2");
                   });
            // Require authentication globally (optional)
            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/");
            });
            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

        }


        public JwtSecurityToken GetJwtPayload(HttpContext myContext)
        {
            var handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(myContext.GetTokenAsync("access_token").Result);
        }

        public string GetJwtClaim(HttpContext myContext, string theClaim)
        {
            JwtSecurityToken jwtPayload = GetJwtPayload(myContext);
            return jwtPayload.Claims.FirstOrDefault(claim => claim.Type == theClaim).Value;
        }
    }

    static public class MyConfiguration
    {
        static ConfigurationManager _config;
        static public void Set(ConfigurationManager config)
        {
            _config = config;
        }

        static public ConfigurationManager Get()
        {
            return _config;
        }

    }
}
