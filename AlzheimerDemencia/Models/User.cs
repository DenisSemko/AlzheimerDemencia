using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AlzheimerDemencia.Models
{
    public class User : IdentityUser<Guid>
    {
        //By default: Id, Email, PasswordHash, PhoneNumber, UserName
        [Required]
        public string Name { get; set; }
        
        public string MiddleName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string UserType { get; set; }
        public string Diagnosis { get; set; }
        public DateTime? StartDate { get; set; }



    }
}
