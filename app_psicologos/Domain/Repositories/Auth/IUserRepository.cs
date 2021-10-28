using System.Collections.Generic;
using System.Threading.Tasks;
using app_psicologos.Domain.Models;

namespace app_psicologos.Domain.Repositories
{
    interface IUserRepository
    {
        Task<bool> DeleteEvaluations();

        Task<string> AddUser(User user);

        Task<List<User>> GetAllUsers();

        Task<User> GetUserLogin(string email,string password);

        Task<List<User>> GetUsersByRol(UserRol rol);
    }
}