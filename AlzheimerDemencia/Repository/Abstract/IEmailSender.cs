using AlzheimerDemencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlzheimerDemencia.Repository.Abstract
{
    interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}
