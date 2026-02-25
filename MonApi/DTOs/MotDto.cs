using System.Collections.Generic;

namespace MonApi.DTOs
{
    public class MotDto
    {
        public string Id { get; set; } = null!;
        public string Texte { get; set; } = null!;
        public string Traduction { get; set; } = null!;
        public string LangueSource { get; set; } = null!;
        public string LangueCible { get; set; } = null!;
        public List<string> Tags { get; set; } = new();
        public string UtilisateurId { get; set; } = null!;
        public string DictionnaireId { get; set; } = null!;
    }
}
