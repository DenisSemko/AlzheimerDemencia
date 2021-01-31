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

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        [Required]
        public string UserType { get; set; }
        public string Diagnosis { get; set; }
        public DateTime? StartDate { get; set; }

        public ICollection<MmseSurvey> MmseSurveys { get; set; }

        public ICollection<PatientNote> PatientNotes { get; set; }
        public ICollection<Treatment> TreatmentPatient { get; set; }
        public ICollection<Treatment> TreatmentDoctor { get; set; }
        public ICollection<ObservationNote> ObservationNotes { get; set; }



    }
}
