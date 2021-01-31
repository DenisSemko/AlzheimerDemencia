using AlzheimerDemencia.Models;
using AlzheimerDemencia.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlzheimerDemencia.Repository.Concrete
{
    public class TreatmentRepository : BaseRepository<Treatment>, ITreatmentRepository
    {
        public TreatmentRepository(ApplicationContext myDbContext) : base(myDbContext) { }
    }
}
