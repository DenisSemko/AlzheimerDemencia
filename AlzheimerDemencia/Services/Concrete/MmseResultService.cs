using AlzheimerDemencia.Models;
using AlzheimerDemencia.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlzheimerDemencia.Services.Concrete
{
    public class MmseResultService : IMmseResultService
    {
        private readonly ApplicationContext mydbContext;
        public int counter = 0;
        public List<string> seasonList;
        public string seasonResult;

        public MmseResultService(ApplicationContext mydbContext)
        {
            this.mydbContext = mydbContext;
        }


        public int GetResult()
        {
            seasonList = new List<string>() { "Autumn", "Winter", "Spring", "Summer" };
            
            foreach(var season in seasonList)
            {
                seasonResult = season;
            }
            var quest_1 = mydbContext.MmseSurvey.SingleOrDefault(q => q.YearQuestion == DateTime.Now.Year.ToString());
            var quest_2 = mydbContext.MmseSurvey.SingleOrDefault(q => q.SeasonQuestion == seasonResult);
            if (quest_1 != null)
            {
                counter++;
            } else if(quest_2 != null)
            {
                counter++;
            }
            return counter;
        }
        
    }
}
