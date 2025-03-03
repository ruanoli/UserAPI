namespace UserAPI.Services.Models
{
    public class CreateAccountResponseModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime AccessDate { get; set; }
        public DateTime DateTimeExpiration { get; set; }
        public string? AccessToken { get; set; }
    }
}
