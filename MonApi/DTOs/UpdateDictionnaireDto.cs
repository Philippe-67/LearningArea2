using System.ComponentModel.DataAnnotations;

namespace MonApi.DTOs
{
    public class UpdateDictionnaireDto
    {
        [Required]
        public string Id { get; set; } = null!;

        public string? LangueSource { get; set; }

        public string? LangueCible { get; set; }

        [MaxLength(100)]
        public string? Nom { get; set; }
    }
}
