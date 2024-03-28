using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PortfolioDataAPI.Models
{
    public class LoginDTO
    {
        [BsonElement("Email")]
        [Required]
        public string Email { get; set; } = string.Empty;
        [BsonElement("Password")]
        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
