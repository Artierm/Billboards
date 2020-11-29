using System;
using System.Collections.Generic;
using System.Text;

namespace BillboardsProject.Presents
{ 
    class LoadAdvertisementPresent
    {
    public LoadAdvertisement loadAdvertisement;
    ApplicationContext database;
    public LoadAdvertisementPresent(LoadAdvertisement loadAdvertisement)
        {
            this.loadAdvertisement = loadAdvertisement;
            database = new ApplicationContext();
            this.loadAdvertisement.addBillboardEvent += LoadVideo;
        }

    public void LoadVideo(object sender, EventArgs e, string nameVideo , int timeVideo)
    {
        Video video = new Video (nameVideo, timeVideo, Authorization.IdUser);
        database.Add(video);
        database.SaveChanges();
    }

}
}
