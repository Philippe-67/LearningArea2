using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MonApi.DTOs
{
    public class UpdateMotDto
    {
        [Required]
        public string Id { get; set; } = null!;

        [MaxLength(200)]
        public string? Texte { get; set; }

        [MaxLength(200)]
        public string? Traduction { get; set; }

        public string? LangueSource { get; set; }

        public string? LangueCible { get; set; }

        public List<string>? Tags { get; set; }
    }
}
