using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MonApi.DTOs
{
    public class CreateMotDto
    {
        [Required(ErrorMessage = "Le texte est requis")]
        [MaxLength(200)]
        public string Texte { get; set; } = null!;

        [Required(ErrorMessage = "La traduction est requise")]
        [MaxLength(200)]
        public string Traduction { get; set; } = null!;

        [Required]
        public string LangueSource { get; set; } = null!;

        [Required]
        public string LangueCible { get; set; } = null!;

        public List<string> Tags { get; set; } = new();

        [Required]
        public string DictionnaireId { get; set; } = null!;
    }
}
