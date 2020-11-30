using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace BillboardsProject.Presenter
{
    class AdvertisementPresenter
    {

        public AdvertisementPage advertisementPage;
        DatabaseContext database;
        public AdvertisementPresenter(AdvertisementPage advertisementPage)
        {
            this.advertisementPage = advertisementPage;
            database = new DatabaseContext();
            this.advertisementPage.DeleteVideoEvent += DeleteVideo;
        }
        public void DeleteVideo(object sender, EventArgs e)
        {
            List<Video> videos = database.Videos.ToList();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (Video)btnSender.DataContext;
            var video = videos.Find(c => c.NameOfVideo == dataContextFromBtn.NameOfVideo);
            database.Videos.Remove(video);
            database.SaveChanges();
        }
    }

}
