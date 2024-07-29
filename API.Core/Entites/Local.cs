using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using api_reservas.Core.Models.BaseModels;

namespace api_reservas.Core.Models
{
    public class Local : BaseEntity
    {
        public string Nome { get; set; }
    }
}
