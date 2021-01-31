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
    public class PatientNoteController : ControllerBase
    {
        private readonly IPatientNoteRepository patientNoteRepository;

        public PatientNoteController(IPatientNoteRepository patientNoteRepository)
        {
            this.patientNoteRepository = patientNoteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientNote>>> Get()
        {
            return Ok(await patientNoteRepository.Get());
        }


        [HttpPost]
        public async Task<ActionResult<PatientNote>> Add(PatientNote patientNote)
        {
            try
            {
                if (patientNote == null)
                {
                    return BadRequest();
                }

                var result = await patientNoteRepository.Add(patientNote);
                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating the new patient note record");
            }
        }

        [HttpPut]
        public async Task<ActionResult<PatientNote>> Update(PatientNote patientNote)
        {
            var result = await patientNoteRepository.Update(patientNote);
            return result;
        }

        [HttpDelete("{id:Guid}")]
        public void DeleteById(Guid id)
        {
            patientNoteRepository.DeleteById(id);
            patientNoteRepository.Save();
        }


    }
}
