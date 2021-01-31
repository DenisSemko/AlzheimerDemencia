using AlzheimerDemencia.Models;
using AlzheimerDemencia.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlzheimerDemencia.Repository.Concrete
{
    public class ObservationNoteRepository : BaseRepository<ObservationNote>, IObservationNoteRepository
    {
        public ObservationNoteRepository(ApplicationContext myDbContext) : base(myDbContext) { }
    }
}
