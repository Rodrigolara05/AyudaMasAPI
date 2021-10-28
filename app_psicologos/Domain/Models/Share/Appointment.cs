using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_psicologos.Domain.Models.Share
{
    public class Appointment
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement]
        public string SpecialistId { get; set; } = string.Empty;

        [BsonElement]
        public string PatientId { get; set; } = string.Empty;

        [BsonElement]
        public string PsychologistId { get; set; } = string.Empty;

        [BsonElement]
        public string EvaluationId { get; set; } = string.Empty;

        [BsonElement]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [BsonElement]
        public DateTime SelectedDate { get; set; } = DateTime.Now;

        [BsonElement]
        public ClinicalOutcome ClinicalOutcome { get; set; }

        [BsonElement]
        public Meeting Meeting { get; set; }

        [BsonIgnore]
        public User Specialist { get; set; } = null;

        [BsonIgnore]
        public User Patient { get; set; } = null;

        [BsonIgnore]
        public Evaluation Evaluation { get; set; } = null;

        [BsonElement]
        public bool Complete { get; set; } = false;
    }
}
