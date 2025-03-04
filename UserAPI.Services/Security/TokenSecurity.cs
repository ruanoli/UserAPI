using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserAPI.Services.Settings;

namespace UserAPI.Services.Security
{
    /// <summary>
    /// Classe para implementar a geração dos tokens JWT
    /// </summary>
    public class TokenSecurity
    {
        private readonly IOptions<JwtSettings>? _jwtSettings;

        public TokenSecurity(IOptions<JwtSettings>? jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string? CreateToken(string userName)
        {
            //gerando a assinatura antifalsificação do token (Verify Signature)
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Value.SecretKey);

            //preenchendo o conteudo do token (Payload)
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                
                Subject = new ClaimsIdentity(new Claim[] {new Claim(ClaimTypes.Name, userName)}), //identificação do nome(email) do usuário para o qual o token está sendo gerado
                Expires = DateTime.Now.AddHours(_jwtSettings.Value.ExpirationInHours), //Data de expiração do token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256) //assinando o token (antifalsificacao)
            };

            //gerando e retornando o token
            var acessToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(acessToken);
        }
    }
}
