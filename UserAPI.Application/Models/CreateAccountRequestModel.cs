﻿using System.ComponentModel.DataAnnotations;

namespace UserAPI.Application.Models
{
    public class CreateAccountRequestModel
    {
        [Required(ErrorMessage = "Informe o nome do usuário.")]
        [MaxLength(50, ErrorMessage = "Máximo de caracteres permitido: {1}")]
        [MinLength(2, ErrorMessage = "Mínimo de caracteres permitido: {1}")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de e-mail válido.")]
        [Required(ErrorMessage = "Informe o e-mail.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
            ErrorMessage = "A senha deve conter pelo menos: no mínimo 8 caracterres, no mínimo uma letra maiúscula, letras minúsculas, números e caracteres especiais.")]
        [Required(ErrorMessage = "Informe a senha.")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Senhas diferentes.")]
        [Required(ErrorMessage = "Confirme a senha.")]
        public string? ConfirmPassword { get; set; }
    }
}
