using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace BillboardsProject.Presenter
{
    class AdvertisementPresenter
    {
        private DatabaseContext _database;
        public AdvertisementPresenter()
        {
            _database = new DatabaseContext();
        }
        public void DeleteVideo(object sender)
        {
            List<Video> videos = _database.Videos.ToList();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (Video)btnSender.DataContext;
            var video = videos.Find(c => c.NameOfVideo == dataContextFromBtn.NameOfVideo);
            _database.Videos.Remove(video);
            _database.SaveChanges();
        }
    }

}
