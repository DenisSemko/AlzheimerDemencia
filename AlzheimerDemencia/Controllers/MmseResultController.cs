using AlzheimerDemencia.Models;
using AlzheimerDemencia.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlzheimerDemencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MmseResultController : ControllerBase
    {
        private readonly IMmseRepository mmseRepository;
        public User user = new User();
        public int counter = 0;

        public MmseResultController(IMmseRepository mmseRepository)
        {
            this.mmseRepository = mmseRepository;
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            var userId = User.Claims.First(c => c.Type == "id").Value;
            Guid userIdObj = Guid.Parse(userId);
            var result = await mmseRepository.GetById(userIdObj);


            return new
            {
                result.Score,
                result.Description
            };
        }
        [HttpPut]
        public async Task<MmseSurvey> Update(MmseSurvey mmse)
        {

            List<string> season = new List<string> { "Autumn", "Winter", "Spring", "Summer" };
            var res = season.Where(s => s.Contains(mmse.SeasonQuestion));
            var q_2 = "";
            foreach(var r in res)
            {
                q_2 = r;
            }
            #region CountIf
            if (mmse.YearQuestion == DateTime.Now.Year.ToString())
            {
                counter++;
            }
            if (mmse.SeasonQuestion == q_2)
            {
                counter++;
            }
            if (mmse.DayQuestion == DateTime.Now.Day.ToString())
            {
                counter++;
            }
            if (mmse.MonthQuestion == DateTime.Now.Month.ToString())
            {
                counter++;
            } 
            if (mmse.DateQuestion == DateTime.Now)
            {
                counter++;
            } 
            if (mmse.CountryQuestion != null)
            {
                counter++;
            } 
            if (mmse.RegionQuestion != null)
            {
                counter++;
            }  
            if (mmse.CityQuestion != null)
            {
                counter++;
            }  
            if(mmse.HomeAddressQuestion == user.Address)
            {
                counter++;
            }  
            if(mmse.NumberBuildingQuestion > 0)
            {
                counter++;
            } 
            if(mmse.FirstObject != null)
            {
                counter++;
            }  
            if(mmse.SecondObject != null)
            {
                counter++;
            }  
            if(mmse.ThirdObject != null)
            {
                counter++;
            }  
            if(mmse.FirstCount == 93)
            {
                counter++;
            }  
            if(mmse.SecondCount == 86)
            {
                counter++;
            }  
            if(mmse.ThirdCount == 79)
            {
                counter++;
            }  
            if(mmse.FourthCount == 72)
            {
                counter++;
            }  
            if(mmse.FifthCount == 65)
            {
                counter++;
            }  
            if(mmse.IsFirstObject == mmse.FirstObject)
            {
                counter++;
            }  
            if(mmse.IsSecondObject == mmse.SecondObject)
            {
                counter++;
            }  
            if(mmse.IsThirdObject == mmse.ThirdObject)
            {
                counter++;
            }  
            if(mmse.FirstShownObject == "Pen" || mmse.FirstShownObject == "Pencil")
            {
                counter++;
            } 
            if(mmse.SecondShownObject == "Pen" || mmse.SecondShownObject == "Pencil")
            {
                counter++;
            }  
            if(mmse.RepeatPhrase == "No ifs, ands, or buts")
            {
                counter++;
            }  
            if(mmse.FirstTask == true)
            {
                counter++;
            }  
            if(mmse.SecondTask == true)
            {
                counter++;
            }  
            if(mmse.ThirdTask == true)
            {
                counter++;
            } 
            if(mmse.FourthTask == true)
            {
                counter++;
            } 
            if(mmse.WriteSentence != null)
            {
                counter++;
            } 
            if(mmse.DrawPicture == true)
            {
                counter++;
            }
            #endregion

            //check counter and add descrp
            switch (counter) 
            {
                case int c when(c > 0 && c <= 10):
                    mmse.Description = "Severe degree of Impairment. It means that the patient is not likely to be testable";
                    break;
                case int c when (c > 10 && c <=20):
                    mmse.Description = "Moderate degree of Impairment. Formal assessment may be helpful if there are specific clinical indications.";
                    break;
                case int c when (c > 20 && c <= 25):
                    mmse.Description = "Mild degree of Impairment. Formal assessment may be helpful to better determine pattern and extent of deficits.";
                    break;
                case int c when (c > 25 && c <= 30):
                    mmse.Description = "Questionably significant degree of Impairment. If clinical signs of cognitive impairment are present, formal assessment of cognition may be valuable.";
                    break;
            }


            mmse.Score = counter;
            var result = await mmseRepository.Update(mmse);
            return result;
        }
    }
}
