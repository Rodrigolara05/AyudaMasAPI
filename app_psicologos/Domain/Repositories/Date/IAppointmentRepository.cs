using app_psicologos.Domain.Models.Share;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_psicologos.Domain.Repositories.Date
{
    public interface IAppointmentRepository
    {
        Task<string> UpdateAppointmentStatus(Appointment appointment);
        Task<string> UpdateAppointment(Appointment appointment);
        Task<bool> DeleteAppointments();
        Task<string> SaveAppointment(Appointment appointment);
        Task<List<Appointment>> GetAllAppointmentsBySpecialistId(string specialistId);
        Task<List<Appointment>> GetAllAppointmentsByPsychologistId(string psychologistId);
        Task<List<Appointment>> GetAllAppointmentsByPatientId(string patientId);
        Task<List<Appointment>> GetAllAppointmentsBySpecialistAndStatus(string specialistId, bool complete);
    }
}
