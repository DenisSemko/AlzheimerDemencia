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
    public class UserProfileController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMmseRepository mmseRepository;

        public UserProfileController(IUserRepository userRepository, IMmseRepository mmseRepository)
        {
            this.userRepository = userRepository;
            this.mmseRepository = mmseRepository;
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            var userId = User.Claims.First(c => c.Type == "id").Value;
            Guid userIdObj = Guid.Parse(userId);
            var result = await userRepository.GetById(userIdObj);
            var resultTest = await userRepository.GetById(userIdObj);

            return new
            {
                result.Name, 
                result.Surname,
                result.UserName,
                result.Email,
                resultTest.PhoneNumber,
                resultTest.Address
            };
        }
    }
}
