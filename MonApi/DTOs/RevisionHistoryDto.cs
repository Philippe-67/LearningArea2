using System;

namespace MonApi.DTOs
{
    public class RevisionHistoryDto
    {
        public string Id { get; set; } = null!;
        public string MotId { get; set; } = null!;
        public string UtilisateurId { get; set; } = null!;
        public string DictionnaireId { get; set; } = null!;
        public DateTime DateRevision { get; set; }
        public bool Reussi { get; set; }
    }
}
