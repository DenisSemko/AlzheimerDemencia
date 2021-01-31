using AlzheimerDemencia.Models;
using AlzheimerDemencia.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlzheimerDemencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservationNoteController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public ObservationNoteController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(await userRepository.Get());
        }

        [HttpPost]
        public async Task<ActionResult<User>> Add(User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }

                var result = await userRepository.Add(user);
                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating the new user record");
            }
        }


        [HttpPut]
        public async Task<ActionResult<User>> Update(User user)
        {
            var result = await userRepository.Update(user);
            return result;
        }

        [HttpDelete("{id:Guid}")]
        public void DeleteById(Guid id)
        {
            userRepository.DeleteById(id);
            userRepository.Save();
        }
    }
}
