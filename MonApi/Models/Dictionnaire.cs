using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MonApi.Models
{
    public class Dictionnaire
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        public string UtilisateurId { get; set; } = null!;
        public string LangueSource { get; set; } = null!;
        public string LangueCible { get; set; } = null!;
        public string Nom { get; set; } = null!; // ex : "Français-Anglais"
    }
}