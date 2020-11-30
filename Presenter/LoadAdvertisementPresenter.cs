using System;
using System.Collections.Generic;
using System.Text;

namespace BillboardsProject.Presents
{ 
    class LoadAdvertisementPresenter
    {
    public LoadAdvertisementPage loadAdvertisement;
    DatabaseContext database;
    public LoadAdvertisementPresenter(LoadAdvertisementPage loadAdvertisement)
        {
            this.loadAdvertisement = loadAdvertisement;
            database = new DatabaseContext();
            this.loadAdvertisement.AddBillboardEvent += LoadVideo;
        }

    public void LoadVideo(object sender, EventArgs e, string nameOfVideo , int timeOfVideo)
    {
        Video video = new Video (nameOfVideo, timeOfVideo, AuthorizationPage.UserId);
        database.Add(video);
        database.SaveChanges();
    }

}
}
