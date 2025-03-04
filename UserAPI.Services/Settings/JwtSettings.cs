namespace UserAPI.Services.Settings
{
    /// <summary>
    /// Captura as configurações do arquivo appSettings
    /// </summary>
    public class JwtSettings
    {
        public string? SecretKey { get; set; }
        public int ExpirationInHours { get; set; }
    }
}
