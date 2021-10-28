using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace app_psicologos.Domain.Models
{
    public class QuestionResult
    {
        [BsonElement]
        public string Answer { get; set; }

        [BsonElement]
        public string Question { get; set; }

        [BsonElement]
        public string Description { get; set; }

        //
        [BsonElement]
        public string PacientId { get; set; }

        [BsonElement]
        public List<Emotion> FaceResponse { get; set; }

        [BsonElement]
        public List<Emotion> WatsonResponse { get; set; }
    }


}
