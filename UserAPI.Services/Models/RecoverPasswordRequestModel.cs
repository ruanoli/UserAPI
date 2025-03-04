using System.ComponentModel.DataAnnotations;

namespace UserAPI.Services.Models
{
    public class RecoverPasswordRequestModel
    {
        [EmailAddress(ErrorMessage = "Informe um endereço de e-mail válido.")]
        [Required(ErrorMessage = "Informe o e-mail")]
        public string? Email { get; set; }
    }
}
