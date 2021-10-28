using MongoDB.Driver;
using app_psicologos.Domain.Models;
using app_psicologos.Domain.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;
using System;

namespace app_psicologos.Repositories
{
    public class UserRepository : IUserRepository
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<User> userCollection;

        public UserRepository()
        {
            userCollection = _repository.db.GetCollection<User>(Constants.USER_DOCUMENT_NAME);
        }

        public async Task<string> AddUser(User user)
        {
            try
            {
                await userCollection.InsertOneAsync(user);
                return user.Id;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
        }

        public async Task<bool> DeleteEvaluations()
        {
            bool result;
            try
            {
                await _repository.db.DropCollectionAsync(Constants.USER_DOCUMENT_NAME);
                result = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
            return result;
        }

        public async Task<List<User>> GetAllUsers()
        {   
            return await userCollection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<User> GetUserLogin(string Email,string Password)
        {
            User Fresult = null;
            try
            {
                var result = await userCollection.FindAsync(r => r.Email == Email && r.Password == Password);
                Fresult = result.FirstOrDefault();
            }
            catch (System.Exception)
            {
                return null;
            }
            return Fresult;
        }

        public async Task<List<User>> GetUsersByRol(UserRol rol)
        {
            List<User> users = null;
            try
            {
                var usersFiltered = await userCollection.FindAsync(user => user.Rol == rol);
                users = await usersFiltered.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Error",ex);
            }
            return users;
        }

    }
}