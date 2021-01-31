using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlzheimerDemencia.Models;
using AlzheimerDemencia.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlzheimerDemencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserAuthController(IUserService userService)
        {
            this._userService = userService;
        }

            [HttpPost]
            [Route("registration")]
            public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
            {
                var authResponse = await _userService.RegisterAsync(registerModel);

                if (!authResponse.Success)
                {
                    return BadRequest(new AuthFailedResponse
                    {
                        Errors = authResponse.Errors
                    });
                }

                return Ok(new AuthSuccessResponse
                {
                    AccessToken = authResponse.AccessToken
                });
            }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var authResponse = await _userService.LoginAsync(loginModel);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                AccessToken = authResponse.AccessToken
            });
        }


    }
    }

