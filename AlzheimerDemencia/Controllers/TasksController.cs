﻿using AlzheimerDemencia.Models;
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
    public class TasksController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public TasksController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(await userRepository.Get());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<User>> GetById(Guid id)
        {
            try
            {
                var result = await userRepository.GetById(id);

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

        
        [HttpDelete("{id:Guid}")]
        public void DeleteById(Guid id)
        {
            userRepository.DeleteById(id);
            userRepository.Save();
        }
    }
}
