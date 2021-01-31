using AlzheimerDemencia.Domain;
using AlzheimerDemencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlzheimerDemencia.Services
{
    public interface IUserService
    {
        Task<AuthenticationResult> RegisterAsync(RegisterModel user);
        Task<AuthenticationResult> LoginAsync(LoginModel user);
    }
}
