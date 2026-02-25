using System.Collections.Generic;

namespace MonApi.DTOs
{
    public class UtilisateurDto
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<string> Roles { get; set; } = new();
    }
}
