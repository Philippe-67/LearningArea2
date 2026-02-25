namespace MonApi.DTOs
{
    public class DictionnaireDto
    {
        public string Id { get; set; } = null!;
        public string UtilisateurId { get; set; } = null!;
        public string LangueSource { get; set; } = null!;
        public string LangueCible { get; set; } = null!;
        public string Nom { get; set; } = null!;
    }
}
