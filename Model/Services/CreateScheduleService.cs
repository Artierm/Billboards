using BillboardsProject.Model.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace BillboardsProject
{
    class CreateScheduleService
    {
        private DatabaseContext _database;
        CreateScheduleService()
        {
            _database = new DatabaseContext();
        }

        public void CreateSchedule(object sender)
        {
            List<Video> videos = _database.Videos.ToList();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (Video)btnSender.DataContext;
            var video = videos.Find(c => c.NameOfVideo == dataContextFromBtn.NameOfVideo);
            CountVideosRepeat countVideosRepeat = new CountVideosRepeat();
            _database.Videos.Remove(video);
            _database.SaveChanges();
        }


    }
}
