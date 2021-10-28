using System.Collections.Generic;
using System.Threading.Tasks;
using app_psicologos.Domain.Models;
using app_psicologos.Domain.Models.Share;
using MongoDB.Bson;

namespace app_psicologos.Domain.Repositories
{
    interface IScheduleRepository
    {
        Task UpdateSchedule(string userId, Appointment appointment);
        Task<string> SaveSchedule(Schedule schedule);
        Task<List<Schedule>> GetAllSchedulesByUserId(string userId);
        Task<List<Schedule>> GetAllSchedulesByUserAndAvailability(string userId, bool available);
        Task<List<Schedule>> GetAllSchedulesByUserAndMonth(string userId, string month);

        //Task AddSchedule(Schedule schedule);

        //Task UpdateSchedule(Schedule schedule);
        //Task DeleteSchedule(string scheduleId);
        //Task<Schedule> GetScheduleById(string scheduleId);

        //Task<List<Schedule>> GetAllSchedules();

        //Task<List<Schedule>> GetAllSchedulesByDate(int Year);

    }
}