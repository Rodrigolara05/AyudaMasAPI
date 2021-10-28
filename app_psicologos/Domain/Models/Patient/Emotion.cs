using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace app_psicologos.Domain.Models
{
    public class Emotion
    {
        [BsonElement]
        public double Score { get; set; }
        [BsonElement]
        public string Name { get; set; }
      
       

    }


}
