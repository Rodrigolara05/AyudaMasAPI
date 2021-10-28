using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_psicologos.Domain.Models.Share
{
    public class Meeting
    {
        [BsonElement]
        public string Platform { get; set; }
        
        [BsonElement]
        public string Url { get; set; }
    }
}
