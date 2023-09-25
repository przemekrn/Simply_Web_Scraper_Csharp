using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simply_Web_Scraper
{
    internal class RacerInfo
    {
        public RacerInfo(string place, string name,string surname)
        {
            Place = place;
            Name = name;
            Surname = surname;
        }
        public string Place { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
 
   
