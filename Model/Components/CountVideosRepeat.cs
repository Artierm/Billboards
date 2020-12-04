using System;
using System.Collections.Generic;
using System.Text;

namespace BillboardsProject.Model.Components
{
   
    class CountVideosRepeat
    {
        public int Id { get; set; }

        public Video Video { get; set; }

        public int AmountOfRepeat { get; set; }

        public CountVideosRepeat() { }

        public CountVideosRepeat(Video video, int amountOfRepeat)
        { 
            AmountOfRepeat = amountOfRepeat;
            Video = video;
        }
    }
}
