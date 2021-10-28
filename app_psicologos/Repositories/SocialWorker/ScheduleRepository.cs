using MongoDB.Driver;
using app_psicologos.Domain.Models;
using app_psicologos.Domain.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;
using System;
using System.Linq;
using app_psicologos.Domain.Models.Share;

namespace app_psicologos.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<User> userCollection;

        public ScheduleRepository()
        {
            userCollection = _repository.db.GetCollection<User>(Constants.USER_DOCUMENT_NAME);
        }

        public async Task UpdateSchedule(string userId, Appointment appointment)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(user => user.Id, userId);
                var user = await (await userCollection.FindAsync(user => user.Id == userId)).FirstOrDefaultAsync();
                if (user != null && user.Schedules != null)
                {
                    var schedules = user.Schedules;
                    var shedule = schedules.FirstOrDefault(schedule => schedule.Available
                    && schedule.Datetime.Day == appointment.SelectedDate.Day &&
                    schedule.Datetime.Month == appointment.SelectedDate.Month &&
                    schedule.Datetime.Year == appointment.SelectedDate.Year &&
                    schedule.Datetime.Hour == appointment.SelectedDate.Hour &&
                    schedule.Datetime.Minute == appointment.SelectedDate.Minute);
                    if (shedule != null)
                    {
                        int index = schedules.IndexOf(shedule);
                        shedule.Available = false;
                        schedules[index] = shedule;
                        user.Schedules = schedules;
                        await userCollection.ReplaceOneAsync(filter, user);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
        }

        public async Task<List<Schedule>> GetAllSchedulesByUserAndMonth(string userId, string month)
        {
            List<Schedule> schedules = null;
            try
            {
                var user = await(await userCollection.FindAsync(user => user.Id == userId)).FirstOrDefaultAsync();
                if (user != null)
                    schedules = user.Schedules ?? new List<Schedule>();

                schedules = schedules.Where(schedule => schedule.Datetime.Month == int.Parse(month)).ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
            return schedules;
        }

        public async Task<List<Schedule>> GetAllSchedulesByUserId(string userId)
        {
            List<Schedule> schedules = null;
            try
            {
                var user = await (await userCollection.FindAsync(user => user.Id == userId)).FirstOrDefaultAsync();
                if (user != null)
                    schedules = user.Schedules ?? new List<Schedule>();
                schedules = schedules.OrderBy(schedule => schedule.Datetime).ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
            return schedules;
        }

        public async Task<List<Schedule>> GetAllSchedulesByUserAndAvailability(string userId, bool available)
        {
            List<Schedule> schedules = null;
            try
            {
                var user = await (await userCollection.FindAsync(user => user.Id == userId)).FirstOrDefaultAsync();
                if (user != null)
                    schedules = user.Schedules.Where(schedule=> schedule.Available == available).ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
            return schedules;
        }

        public async Task<string> SaveSchedule(Schedule schedule)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(user => user.Id, schedule.userId);
                var user = await (await userCollection.FindAsync(user => user.Id == schedule.userId)).FirstOrDefaultAsync();
                if (user.Schedules == null)
                    user.Schedules = new List<Schedule>();
                user.Schedules.Add(schedule);

                await userCollection.ReplaceOneAsync(filter, user);

                return "Ok";
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
        }

        //public async Task AddSchedule(Schedule schedule)
        //{
        //    await Collection.InsertOneAsync(schedule);
        //}
        //public async Task<List<Schedule>> GetAllSchedules()
        //{
        //    return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        //}

        //public async Task UpdateSchedule(Schedule schedule)
        //{
        //    var filter = Builders<Schedule>.Filter.Eq(s => s.Id, schedule.Id);
        //    await Collection.ReplaceOneAsync(filter, schedule);
        //}
        //public async Task DeleteSchedule(string scheduleId)
        //{
        //    var filter = Builders<Schedule>.Filter.Eq(s => s.Id, new ObjectId(scheduleId));
        //    await Collection.DeleteOneAsync(filter);
        //}
        //public async Task<Schedule> GetScheduleById(string scheduleId)
        //{
        //    return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(scheduleId) } }).Result.FirstAsync();
        //}

        //public async Task<List<Schedule>> GetAllSchedulesByDate(int Year)
        //{

        //    return await Collection.FindAsync(new BsonDocument { { "Year", Year } }).Result.ToListAsync();

        //}

    }
}