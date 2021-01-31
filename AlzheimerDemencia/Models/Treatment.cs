using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlzheimerDemencia.Models
{
    public class Treatment
    {
        [Required]
        public Guid Id { get; set; }
        public User DoctorUserId { get; set; }
        public User PatientUserId { get; set; }
        public string Description { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public ICollection<ObservationNote> ObservationNotes { get; set; }
    }
}
