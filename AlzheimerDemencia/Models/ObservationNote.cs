using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlzheimerDemencia.Models
{
    public class ObservationNote
    {
        [Required]
        public Guid Id { get; set; }
        public User DoctorUserId { get; set; }
        public string Description { get; set; }
        public Treatment Treatment { get; set; }
    }
}
