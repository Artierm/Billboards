using System.Collections.Generic;
using System.Net;

namespace DAL.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public Billboard Billboard { get; set; }

        public string BillboardAddress { get; set; }
  

        public User User { get; set; }
        //public string Owner { get; set; }

        //public List<Video> Videos { get; set; } 

        public Schedule() { }

        public Schedule(Billboard billboard, string billboardAddres, User user)
        {
            User = user;
            Billboard = billboard;
            BillboardAddress = billboardAddres;
        }
    }
}
