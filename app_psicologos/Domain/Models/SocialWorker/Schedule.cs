using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace app_psicologos.Domain.Models
{
    public class Schedule 
    {
        [BsonElement]
        public DateTime Datetime { get; set; }

        [BsonElement]
        public bool Available { get; set; } = true;
        
        [BsonElement]
        public string userId { get; set; }

    }
}
