﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlzheimerDemencia.Models;
using AlzheimerDemencia.Repository.Abstract;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace AlzheimerDemencia.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
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
