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
    public class MmseController : ControllerBase
    {
        private readonly IMmseRepository mmseRepository;

        public MmseController(IMmseRepository mmseRepository)
        {
            this.mmseRepository = mmseRepository;
        }

        //GET api/Mmse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MmseSurvey>>> Get()
        {
            return Ok(await mmseRepository.Get());
        }

        //GET api/Mmse/id
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<MmseSurvey>> GetById(Guid id)
        {
            try
            {
                var result = await mmseRepository.GetById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //POST 
        [HttpPost]
        public async Task<ActionResult<MmseSurvey>> Add(MmseSurvey mmseSurvey)
        {
            try
            {
                if (mmseSurvey == null)
                {
                    return BadRequest();
                }

                var result = await mmseRepository.Add(mmseSurvey);
                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating the test data");
            }
        }

    }
}
