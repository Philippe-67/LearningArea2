using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MonApi.Models
{
    public class Utilisateur
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public List<string> Roles { get; set; } = new();
        // Les langues sont maintenant gérées par les dictionnaires liés à l'utilisateur
    }
}