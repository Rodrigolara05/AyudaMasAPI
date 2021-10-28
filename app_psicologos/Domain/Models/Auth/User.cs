using app_psicologos.Domain.Models.Share;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace app_psicologos.Domain.Models
{
    public enum UserRol
    {
        None,
        Patient,
        SocialWorker,
        Psychologist,
        Psychiatrist
    }

    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public string LastName { get; set; }

        [BsonElement]
        public string Description { get; set; }

        [BsonElement]
        public int? Age { get; set; }

        [BsonElement]
        public string Email { get; set; }

        [BsonElement]
        public string Password { get; set; }

        [BsonElement]
        public UserRol Rol { get; set; } = UserRol.None;

        [BsonElement]
        public string LegalAgreements { get; set; }
        
        [BsonElement]
        public string Photo { get; set; }
        
        [BsonElement]
        public string PsychometricStudy { get; set; }
        
        [BsonElement]
        public string Specialties { get; set; }
        
        [BsonElement]
        public string CV { get; set; }
        
        [BsonElement]
        public string Address { get; set; }
        
        [BsonElement]
        public string DNI { get; set; }
        
        [BsonElement]
        public string Code { get; set; }
        
        [BsonElement]
        public long? CollegiateNumber { get; set; }

        [BsonElement]
        public List<Schedule> Schedules { get; set; } = null;

        [BsonElement]
        public List<Meeting> Meetings { get; set; }

        [BsonElement]
        public List<Review> Reviews { get; set; }
    }


}
