using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace PortfolioDataAPI.Models
{
    public class ApplicationUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
#pragma warning disable IDE1006 // Naming Styles
        public ObjectId _id { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        [BsonElement("UserName")]
        public string UserName { get; set; } = string.Empty;
        [BsonElement("Password")]
        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [BsonElement("Email")]
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
    }
}
