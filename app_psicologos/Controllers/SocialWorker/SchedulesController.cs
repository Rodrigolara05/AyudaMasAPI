using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using app_psicologos.Domain.Models;
using app_psicologos.Domain.Repositories;
using app_psicologos.Repositories;
using System;

namespace app_psicologos.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class SchedulesController : Controller
    {
        private IScheduleRepository db = new ScheduleRepository();

        [HttpPost]
        public async Task<IActionResult> SaveAppointment([FromBody] Schedule schedule)
        {
            try
            {
                if (schedule == null)
                    return NotFound();

                var result = await db.SaveSchedule(schedule);

                return Created("Ok", true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ByUserAndMonth")]
        public async Task<IActionResult> GetAllSchedulesByUserAndMonth(string userId,string month)
        {
            try
            {
                var result = await db.GetAllSchedulesByUserAndMonth(userId, month);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("ByUser")]
        public async Task<IActionResult> GetAllSchedulesByUserId(string userId)
        {
            try
            {
                var result = await db.GetAllSchedulesByUserId(userId);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ByUserAndAvailability")]
        public async Task<IActionResult> GetAllSchedulesByUserIdAndAvailability(string userId,bool available)
        {
            try
            {
                var result = await db.GetAllSchedulesByUserAndAvailability(userId, available);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /*
         [HttpGet]
        public async Task<IActionResult> GetAllSchedules()
        {
            return Ok(await db.GetAllSchedules());
        }
         
         */
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetScheduleById(string id)
        //{
        //    return Ok(await db.GetScheduleById(id));
        //}
        //[HttpGet("/api/SchedulesByDate/{Year}")]
        //public async Task<IActionResult> GetScheduleByDate(int Year)
        //{

        //    return Ok(await db.GetAllSchedulesByDate(Year));
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddSchedule([FromBody] Schedule schedule, string specialistId)
        //{

        //    if (schedule == null)
        //    {
        //        return BadRequest();
        //    }
        //    if (schedule != null)
        //    {
        //        await db.AddSchedule(schedule);
        //    }
        //    return Created("Created", true);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateSchedule([FromBody] Schedule schedule, string id)
        //{
        //    if (schedule == null)
        //    {
        //        return BadRequest();
        //    }
        //    if (schedule != null)
        //    {
        //        schedule.Id = new MongoDB.Bson.ObjectId(id);
        //        await db.UpdateSchedule(schedule);

        //    }
        //    return Created("Created", true);
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteSchedule(string id)
        //{
        //    await db.DeleteSchedule(id);
        //    return NoContent();
        //}
    }
}