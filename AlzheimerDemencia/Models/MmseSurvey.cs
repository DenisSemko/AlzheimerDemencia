using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AlzheimerDemencia.Models
{
    public class MmseSurvey
    {
        public Guid Id { get; set; }
        
        public User User{ get; set; }
        public DateTime DataSubmit { get; set; }
        // 1-st block
        [Required]
        public string YearQuestion { get; set; }
        [Required]
        public string SeasonQuestion { get; set; }
        [Required]
        public string DayQuestion { get; set; }
        [Required]
        public string MonthQuestion { get; set; }
        [Required]
        public DateTime DateQuestion { get; set; }

        //2-d block
        [Required]
        public string CountryQuestion { get; set; }
        [Required]
        public string RegionQuestion { get; set; }
        [Required]
        public string CityQuestion { get; set; }
        [Required]
        public string HomeAddressQuestion { get; set; }
        [Required]
        public int NumberBuildingQuestion { get; set; }

        //3-d block
        [Required]
        public string FirstObject { get; set; }
        [Required]
        public string SecondObject { get; set; }
        [Required]
        public string ThirdObject { get; set; }

        //4-th block
        [Required]
        public int FirstCount { get; set; }
        [Required]
        public int SecondCount { get; set; }
        [Required]
        public int ThirdCount { get; set; }
        [Required]
        public int FourthCount { get; set; }
        [Required]
        public int FifthCount { get; set; }

        //5-th block is the 3-d block
        public string IsFirstObject { get; set; }
        public string IsSecondObject { get; set; }
        public string IsThirdObject { get; set; }

        //6-th block
        [Required]
        public string FirstShownObject { get; set; }
        [Required]
        public string SecondShownObject { get; set; }

        //7-th block
        [Required]
        public string RepeatPhrase { get; set; }

        //8-th block
        [Required]
        public bool FirstTask { get; set; }
        [Required]
        public bool SecondTask { get; set; }
        [Required]
        public bool ThirdTask { get; set; }

        //9-th block
        [Required]
        public bool FourthTask { get; set; }

        //10-th block
        [Required]
        public string WriteSentence { get; set; }

        //11-th block
        [Required]
        public bool DrawPicture { get; set; }

        //Result
        public int Score { get; set; }
        public string Description { get; set; }

    }
}
