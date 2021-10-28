using app_psicologos.Domain.Models;
using app_psicologos.Domain.Repositories.Patient;
using app_psicologos.Repositories.Patient;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace app_psicologos.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class EvaluationController : Controller
    {
        private IEvaluationRepository evaluationRepository = new EvaluationRepository();

        [HttpDelete]
        public async Task<IActionResult> DeleteEvaluations()
        {
            try
            {
                var result = await evaluationRepository.DeleteEvaluations();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> GetEvaluationById(string evaluationId)
        {
            try
            {
                var result = await evaluationRepository.GetEvaluationById(evaluationId);

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
        public async Task<IActionResult> GetEvaluations()
        {
            try
            {
                var result = await evaluationRepository.GetEvaluations();

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveEvaluation([FromBody] Evaluation evaluation)
        {
            try
            {
                if (evaluation == null)
                    return NotFound();

                var result = await evaluationRepository.SaveEvaluation(evaluation);

                var str = "{ \"id\": \"" + result+ "\" }";
                return Created(nameof(result), str);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ByUser")]
        public async Task<IActionResult> GetEvaluationsByUserId(string patientId)
        {
            try
            {
                var result = await evaluationRepository.GetEvaluationsByUserId(patientId);

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