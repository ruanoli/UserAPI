using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserAPI.Services.Security;
using UserAPI.Services.Settings;

namespace UserAPI.Services.Configurations
{
    public class JwtConfiguration
    {
        /// <summary>
        /// Método para configurar a política de autenticação do projeto.
        /// </summary>
        /// <param name="builder"></param>
        public static void Configure(WebApplicationBuilder builder)
        {
            //definindo a política de autenticação jwt
            builder.Services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(
                    bearer =>
                    {
                        bearer.RequireHttpsMetadata = false;
                        bearer.SaveToken = true;
                        bearer.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                                builder.Configuration.GetSection("JwtSettings").GetSection("SecretKey").Value)),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                );

            
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings")); //mapear as classes criadas para o JWT
            builder.Services.AddTransient<TokenSecurity>(); //registrando a classe TokenSecurity
        }
    }
}
