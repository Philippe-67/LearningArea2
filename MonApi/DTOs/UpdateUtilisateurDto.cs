using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MonApi.DTOs
{
    public class UpdateUtilisateurDto
    {
        [Required]
        public string Id { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        public string? Email { get; set; }

        [MinLength(6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères")]
        public string? Password { get; set; }
    }
}
