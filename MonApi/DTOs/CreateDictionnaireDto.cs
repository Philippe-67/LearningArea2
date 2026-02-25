using System.ComponentModel.DataAnnotations;

namespace MonApi.DTOs
{
    public class CreateDictionnaireDto
    {
        [Required]
        public string LangueSource { get; set; } = null!;

        [Required]
        public string LangueCible { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Nom { get; set; } = null!;
    }
}
