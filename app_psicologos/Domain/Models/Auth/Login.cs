using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace app_psicologos.Domain.Models.Auth
{
    public class Login
    {

        [BsonElement]
        public string Email { get; set; }

        [BsonElement]
        public string Password { get; set; }



    }


}
