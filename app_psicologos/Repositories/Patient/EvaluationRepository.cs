using app_psicologos.Domain.Models;
using app_psicologos.Domain.Repositories.Patient;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_psicologos.Repositories.Patient
{
    public class EvaluationRepository : IEvaluationRepository
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Evaluation> EvaluationCollection;

        public EvaluationRepository()
        {
            EvaluationCollection = _repository.db.GetCollection<Evaluation>(Constants.EVALUATION_DOCUMENT_NAME);
        }

        public async Task<bool> DeleteEvaluations()
        {
            bool result;
            try
            {
                await _repository.db.DropCollectionAsync(Constants.EVALUATION_DOCUMENT_NAME);
                result = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
            return result;
        }

        public async Task<Evaluation> GetEvaluationById(string evaluationId)
        {
            Evaluation evaluation = null;
            try
            {
                var evaluatiosResult = await(await EvaluationCollection.FindAsync(eval => eval.Id == evaluationId)).FirstOrDefaultAsync();
                if (evaluatiosResult != null)
                    evaluation = evaluatiosResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
            return evaluation;
        }

        public async Task<List<Evaluation>> GetEvaluations()
        {
            List<Evaluation> evaluations = null;
            try
            {
                var evaluationsResult = await EvaluationCollection.Find(Builders<Evaluation>.Filter.Empty).ToListAsync();
                if (evaluationsResult != null)
                    evaluations = evaluationsResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
            return evaluations;
        }

        public async Task<List<Evaluation>> GetEvaluationsByUserId(string patientId)
        {
            List<Evaluation> evaluations = null;
            try
            {
                var evaluationsResult = await(await EvaluationCollection.FindAsync(eval => eval.PatientId == patientId)).ToListAsync();
                if (evaluationsResult != null)
                    evaluations = evaluationsResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
            return evaluations;
        }

        public async Task<string> SaveEvaluation(Evaluation evaluation)
        {
            try
            {
                await EvaluationCollection.InsertOneAsync(evaluation);
                return evaluation.Id;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error", ex);
            }
        }
    }
}
