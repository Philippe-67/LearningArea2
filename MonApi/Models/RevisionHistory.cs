using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MonApi.Models
{
    public class RevisionHistory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        public string MotId { get; set; } = null!;
        public string UtilisateurId { get; set; } = null!;
        public string DictionnaireId { get; set; } = null!;
        public DateTime DateRevision { get; set; }
        public bool Reussi { get; set; }
    }
}