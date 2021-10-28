using app_psicologos.Domain.Models.Share;
using app_psicologos.Domain.Repositories.Date;
using app_psicologos.Repositories.Share;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_psicologos.Controllers.Share
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private IAppointmentRepository db = new AppointmentRepository();

        [HttpPut]
        public async Task<IActionResult> UpdateAppointment([FromBody] Appointment appointment)
        {
            try
            {
                var result = await db.UpdateAppointment(appointment);

                var str = "{ \"id\": \"" + result + "\" }";
                return Ok(str);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("Status")]
        public async Task<IActionResult> UpdateAppointmentStatus([FromBody] Appointment appointment)
        {
            try
            {
                var result = await db.UpdateAppointmentStatus(appointment);

                var str = "{ \"id\": \"" + result + "\" }";
                return Ok(str);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppointments()
        {
            try
            {
                var result = await db.DeleteAppointments();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveAppointment([FromBody] Appointment appointment)
        {
            try
            {
                if (appointment == null)
                    return NotFound();

                var result = await db.SaveAppointment(appointment);

                return Created(nameof(result), result.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ByPatient")]
        public async Task<IActionResult> GetAllAppointmentsByPatientId(string patientId)
        {
            try
            {
                var result = await db.GetAllAppointmentsByPatientId(patientId);

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
        [Route("BySpecialist")]
        public async Task<IActionResult> GetAllAppointmentsBySpecialistId(string specialistId)
        {
            try
            {
                var result = await db.GetAllAppointmentsBySpecialistId(specialistId);

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
        [Route("ByPsychologist")]
        public async Task<IActionResult> GetAllAppointmentsByPsychologistId(string psychologistId)
        {
            try
            {
                var result = await db.GetAllAppointmentsByPsychologistId(psychologistId);

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
        [Route("BySpecialistAndStatus")]
        public async Task<IActionResult> GetAllAppointmentsBySpecialistAndStatus(string specialistId, string complete)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(specialistId) || string.IsNullOrWhiteSpace(complete))
                {
                    return BadRequest();
                }

                var isBoolean = bool.TryParse(complete, out bool resultBool);
                if (!isBoolean)
                    return BadRequest();

                var result = await db.GetAllAppointmentsBySpecialistAndStatus(specialistId, resultBool);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
