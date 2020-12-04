using System;
using System.Collections.Generic;
using System.Text;

namespace BillboardsProject.Model.Components
{
   
    class Schedule
    {
        public int Id { get; set; }

        public string Owner { get; set; }

        public List<CountVideosRepeat> CountVideosRepeat { get; set; } 

        public Schedule() { }

        public Schedule(string owner, List<CountVideosRepeat> countVideosRepeat)
        {
            Owner = owner;
            CountVideosRepeat = countVideosRepeat;
        }
    }
}
