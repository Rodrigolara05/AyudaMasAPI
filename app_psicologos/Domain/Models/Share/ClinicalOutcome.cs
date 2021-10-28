using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_psicologos.Domain.Models.Share
{
    public class ClinicalOutcome
    {

        [BsonElement]
        public string Diagnostic { get; set; }

        [BsonElement]
        public string Result { get; set; }

        [BsonElement]
        public string Observation { get; set; }

        [BsonElement]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [BsonElement]
        public Meeting Meeting { get; set; }
    }
}
