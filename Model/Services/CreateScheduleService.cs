using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Billbort
{
    public class CreateScheduleService
    {
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        public CreateScheduleService(ICreateNewVideoRepository createNewVideoRepository)
        {
            _createNewVideoRepository = createNewVideoRepository;
        }


        public void CreateSchedule(object sender)
        {

            var videos = _createNewVideoRepository.GetAll();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (Video)btnSender.DataContext;
            var video = _createNewVideoRepository.GetByName(dataContextFromBtn.NameOfVideo);
            //CountVideosRepeat countVideosRepeat = new CountVideosRepeat();
            _createNewVideoRepository.Delete(video);
        }
    }
}
