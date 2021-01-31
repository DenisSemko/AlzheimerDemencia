﻿using AlzheimerDemencia.Models;
using AlzheimerDemencia.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlzheimerDemencia.Repository.Concrete
{
    public class PatientNoteRepository : BaseRepository<PatientNote>, IPatientNoteRepository
    {
        public PatientNoteRepository(ApplicationContext myDbContext) : base(myDbContext) { }
    }
}
