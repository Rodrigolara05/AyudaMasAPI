using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_psicologos.Domain.Models
{
    public class Evaluation
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement]
        public string PatientId { get; set; }

        [BsonElement]
        public List<QuestionResult> QuestionResults { get; set; }

        [BsonElement]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [BsonElement]
        public bool Sent { get; set; }

    }
}
