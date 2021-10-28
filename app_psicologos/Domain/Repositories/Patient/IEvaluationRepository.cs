using app_psicologos.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_psicologos.Domain.Repositories.Patient
{
    public interface IEvaluationRepository
    {
        Task<bool> DeleteEvaluations();
        Task<string> SaveEvaluation(Evaluation evaluation);
        Task<List<Evaluation>> GetEvaluationsByUserId(string patientId);
        Task<List<Evaluation>> GetEvaluations();
        Task<Evaluation> GetEvaluationById(string evaluationId);
    }
}
