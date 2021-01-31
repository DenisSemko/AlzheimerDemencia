using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlzheimerDemencia.Models
{
    public class PatientNote
    {
        [Required]
        public Guid Id { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
