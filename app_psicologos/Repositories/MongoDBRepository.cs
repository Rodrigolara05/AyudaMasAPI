using MongoDB.Driver;
namespace app_psicologos.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;
        public IMongoDatabase db;
        public MongoDBRepository()
        {
            client = new MongoClient("mongodb+srv://AyudamasAdmin:Ayudamasdb@cluster0.daviw.mongodb.net/psicologodb?retryWrites=true&w=majority");
            db = client.GetDatabase("psicologodb");
        }
    }
}
