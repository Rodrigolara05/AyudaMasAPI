using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using app_psicologos.Domain.Models;
using app_psicologos.Domain.Repositories;
using app_psicologos.Repositories;
using app_psicologos.Domain.Models.Auth;
using System;

namespace app_psicologos.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserRepository db = new UserRepository();

        [HttpDelete]
        public async Task<IActionResult> DeleteEvaluations()
        {
            try
            {
                var result = await db.DeleteEvaluations();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await db.GetAllUsers());
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                    return NotFound();

                var result = await db.AddUser(user);
                return Created(nameof(result), result.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ByRol/{rol}")]
        public async Task<IActionResult> GetUsersByRol(UserRol rol)
        {
            var result = await db.GetUsersByRol(rol);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Login([FromBody] Login user)
        {
            try
            {
                if (user == null)
                    return NotFound();

                var result = await db.GetUserLogin(user.Email, user.Password);

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