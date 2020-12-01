using System;
using System.Collections.Generic;
using System.Text;

namespace BillboardsProject.Presents
{ 
    class LoadAdvertisementPresenter
    {
    private DatabaseContext _database;
    public LoadAdvertisementPresenter()
        {
            _database = new DatabaseContext();
        }

    public void LoadVideo(string nameOfVideo , int timeOfVideo)
    {
        Video video = new Video (nameOfVideo, timeOfVideo, AuthorizationPage.UserId);
        _database.Add(video);
        _database.SaveChanges();
    }
}
}
