using app_psicologos.Domain.Models;
using app_psicologos.Domain.Models.Share;
using app_psicologos.Domain.Repositories.Date;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_psicologos.Repositories.Share
{
    public class AppointmentRepository : IAppointmentRepository
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Appointment> appointmentCollection;
        private IMongoCollection<User> userCollection;
        private IMongoCollection<Evaluation> evaluationCollection;

        public AppointmentRepository()
        {
            appointmentCollection = _repository.db.GetCollection<Appointment>(Constants.APPOINTMENT_DOCUMENT_NAME);
            userCollection = _repository.db.GetCollection<User>(Constants.USER_DOCUMENT_NAME);
            evaluationCollection = _repository.db.GetCollection<Evaluation>(Constants.EVALUATION_DOCUMENT_NAME);
        }

        public async Task<string> UpdateAppointment(Appointment appointment)
        {
            try
            {
                var filter = Builders<Appointment>.Filter.Eq(a => a.Id, appointment.Id);

                if (string.IsNullOrWhiteSpace(appointment.SpecialistId))
                {
                    var appoint = await (await appointmentCollection.FindAsync(u => u.Id == appointment.Id)).FirstOrDefaultAsync();
                    if (appoint != null)
                    {
                        appointment.SpecialistId = appoint.SpecialistId;
                    }
                }

                await appointmentCollection.ReplaceOneAsync(filter, appointment);
                return appointment.Id;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
        }
        public async Task<bool> DeleteAppointments()
        {
            bool result;
            try
            {
                await _repository.db.DropCollectionAsync(Constants.APPOINTMENT_DOCUMENT_NAME);
                result = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
            return result;
        }

        public async Task<List<Appointment>> GetAllAppointmentsByPatientId(string patientId)
        {
            List<Appointment> appointments = null;
            try
            {
                var filterAppointments = await appointmentCollection.FindAsync(appoint => appoint.PatientId == patientId);
                appointments = await filterAppointments.ToListAsync();
                foreach (var appoint in appointments)
                {
                    if (!string.IsNullOrWhiteSpace(appoint.PatientId))
                    {
                        appoint.Patient = await (await userCollection.FindAsync(u => u.Id == appoint.PatientId)).FirstOrDefaultAsync();
                    }
                    if (!string.IsNullOrWhiteSpace(appoint.SpecialistId))
                    {
                        appoint.Specialist = await (await userCollection.FindAsync(u => u.Id == appoint.SpecialistId)).FirstOrDefaultAsync();
                    }
                    if (!string.IsNullOrWhiteSpace(appoint.EvaluationId))
                    {
                        appoint.Evaluation = await (await evaluationCollection.FindAsync(u => u.Id == appoint.EvaluationId)).FirstOrDefaultAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
            return appointments;
        }

        public async Task<List<Appointment>> GetAllAppointmentsBySpecialistAndStatus(string specialistId, bool complete)
        {
            List<Appointment> appointments = null;
            try
            {
                var filterAppointments = await appointmentCollection.FindAsync(appoint => appoint.SpecialistId == specialistId && appoint.Complete == complete);
                appointments = await filterAppointments.ToListAsync();
                foreach (var appoint in appointments)
                {
                    if (!string.IsNullOrWhiteSpace(appoint.PatientId))
                    {
                        appoint.Patient = await (await userCollection.FindAsync(u => u.Id == appoint.PatientId)).FirstOrDefaultAsync();
                    }
                    if (!string.IsNullOrWhiteSpace(appoint.SpecialistId))
                    {
                        appoint.Specialist = await (await userCollection.FindAsync(u => u.Id == appoint.SpecialistId)).FirstOrDefaultAsync();
                    }
                    if (!string.IsNullOrWhiteSpace(appoint.EvaluationId))
                    {
                        appoint.Evaluation = await (await evaluationCollection.FindAsync(u => u.Id == appoint.EvaluationId)).FirstOrDefaultAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
            return appointments;
        }

        public async Task<List<Appointment>> GetAllAppointmentsBySpecialistId(string specialistId)
        {
            List<Appointment> appointments = null;
            try
            {
                var filterAppointments = await appointmentCollection.FindAsync(appoint => appoint.SpecialistId == specialistId);
                appointments = await filterAppointments.ToListAsync();
                foreach (var appoint in appointments)
                {
                    if (!string.IsNullOrWhiteSpace(appoint.PatientId))
                    {
                        appoint.Patient = await (await userCollection.FindAsync(u => u.Id == appoint.PatientId)).FirstOrDefaultAsync();
                    }
                    if (!string.IsNullOrWhiteSpace(appoint.SpecialistId))
                    {
                        appoint.Specialist = await (await userCollection.FindAsync(u => u.Id == appoint.SpecialistId)).FirstOrDefaultAsync();
                    }
                    if (!string.IsNullOrWhiteSpace(appoint.EvaluationId))
                    {
                        appoint.Evaluation = await (await evaluationCollection.FindAsync(u => u.Id == appoint.EvaluationId)).FirstOrDefaultAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
            return appointments;
        }

        public async Task<List<Appointment>> GetAllAppointmentsByPsychologistId(string psychologistId)
        {
            List<Appointment> appointments = null;
            try
            {
                var filterAppointments = await appointmentCollection.FindAsync(appoint => appoint.PsychologistId == psychologistId);
                appointments = await filterAppointments.ToListAsync();
                foreach (var appoint in appointments)
                {
                    if (!string.IsNullOrWhiteSpace(appoint.PatientId))
                    {
                        appoint.Patient = await (await userCollection.FindAsync(u => u.Id == appoint.PatientId)).FirstOrDefaultAsync();
                    }
                    if (!string.IsNullOrWhiteSpace(appoint.SpecialistId))
                    {
                        appoint.Specialist = await (await userCollection.FindAsync(u => u.Id == appoint.SpecialistId)).FirstOrDefaultAsync();
                    }
                    if (!string.IsNullOrWhiteSpace(appoint.EvaluationId))
                    {
                        appoint.Evaluation = await (await evaluationCollection.FindAsync(u => u.Id == appoint.EvaluationId)).FirstOrDefaultAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
            return appointments;
        }
        public async Task<string> SaveAppointment(Appointment appointment)
        {
            try
            {
                await appointmentCollection.InsertOneAsync(appointment);
                ScheduleRepository scheduleRepository = new ScheduleRepository();
                if (!string.IsNullOrWhiteSpace(appointment.SpecialistId) && appointment.SelectedDate != null)
                {
                    await scheduleRepository.UpdateSchedule(appointment.SpecialistId, appointment);
                }

                return appointment.Id;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
        }

        public async Task<string> UpdateAppointmentStatus(Appointment appointment)
        {
            try
            {
                var filter = Builders<Appointment>.Filter.Eq(a => a.Id, appointment.Id);
                var appoin = await (await appointmentCollection.FindAsync(a => a.Id == appointment.Id)).FirstOrDefaultAsync();

                appoin.Complete = appointment.Complete;

                await appointmentCollection.ReplaceOneAsync(filter, appoin);

                return appointment.Id;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
        }

    }
}
