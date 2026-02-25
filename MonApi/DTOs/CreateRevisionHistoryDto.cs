using System;
using System.ComponentModel.DataAnnotations;

namespace MonApi.DTOs
{
    public class CreateRevisionHistoryDto
    {
        [Required]
        public string MotId { get; set; } = null!;

        [Required]
        public string DictionnaireId { get; set; } = null!;

        [Required]
        public bool Reussi { get; set; }
    }
}
