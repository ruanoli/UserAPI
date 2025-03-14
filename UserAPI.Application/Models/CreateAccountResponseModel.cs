namespace UserAPI.Application.Models
{
    public class CreateAccountResponseModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime DateTimeRegister { get; set; }
    }
}
