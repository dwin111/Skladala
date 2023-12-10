using MongoDB.Bson.Serialization.Attributes;
using Skladala.Core.Models;
using Skladala.Persistence.Interfaces;

namespace Skladala.Persistence.Models
{
    public class ProductDto: Product, IProductDto
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public bool IsFoodProduct { get; set; }

    }
}
