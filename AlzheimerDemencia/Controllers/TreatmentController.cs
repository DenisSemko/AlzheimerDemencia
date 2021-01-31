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
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentRepository treatmentRepository;

        public TreatmentController(ITreatmentRepository treatmentRepository)
        {
            this.treatmentRepository = treatmentRepository;
        }


        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Treatment>> GetById(Guid id)
        {
            try
            {
                var result = await treatmentRepository.GetById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Treatment>> Add(Treatment treatment)
        {
            try
            {
                if (treatment == null)
                {
                    return BadRequest();
                }

                var result = await treatmentRepository.Add(treatment);
                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating the new user record");
            }
        }


        [HttpPut]
        public async Task<ActionResult<Treatment>> Update(Treatment treatment)
        {
            var result = await treatmentRepository.Update(treatment);
            return result;
        }

        [HttpDelete("{id:Guid}")]
        public void DeleteById(Guid id)
        {
            treatmentRepository.DeleteById(id);
            treatmentRepository.Save();
        }
    }
}
