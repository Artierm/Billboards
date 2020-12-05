using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Billbort
{
    public class CreateScheduleService
    {
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        //public CreateScheduleService(ICreateNewScheduleRepository createNewScheduleRepository)
        //{
        //    _createNewScheduleRepository = createNewScheduleRepository;
        //}


        //public void CreateSchedule(object sender)
        //{
        //    List<Video> videos = _database.Videos.ToList();
        //    Button btnSender = (Button)sender;
        //    var dataContextFromBtn = (Video)btnSender.DataContext;
        //    var video = videos.Find(c => c.NameOfVideo == dataContextFromBtn.NameOfVideo);
        //    CountVideosRepeat countVideosRepeat = new CountVideosRepeat();
        //    _database.Videos.Remove(video);
        //    _database.SaveChanges();
        //}
    }
}
