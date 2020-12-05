using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Linq;
using System.Windows.Controls;

namespace BillboardProject.Service
{
    public class AdvertisementService
    {
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        public AdvertisementService(ICreateNewVideoRepository createNewVideoRepository)
        {
            _createNewVideoRepository = createNewVideoRepository;
        }
        public void DeleteVideo(object sender)
        {
            var videos = _createNewVideoRepository.GetAll();

            Button btnSender = (Button)sender;
            var dataContextFromBtn = (Video)btnSender.DataContext;
            var video = videos.FirstOrDefault(c => c.NameOfVideo == dataContextFromBtn.NameOfVideo);

            _createNewVideoRepository.Delete(video);
        }
    }

}
