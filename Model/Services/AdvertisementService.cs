using System;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Linq;
using System.Windows.Controls;

namespace BillboardProject.Service
{
    public class AdvertisementService
    {
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        public AdvertisementService(ICreateNewVideoRepository createNewVideoRepository, ICreateNewLogRepository createNewLogRepository, ICreateNewUserRepository createNewUserRepository)
        {
            _createNewVideoRepository = createNewVideoRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewUserRepository = createNewUserRepository;
        }
        public void DeleteVideo(object sender)
        {
            var videos = _createNewVideoRepository.GetAll();

            Button btnSender = (Button)sender;
            var dataContextFromBtn = (Video)btnSender.DataContext;
            var video = videos.FirstOrDefault(c => c.NameOfVideo == dataContextFromBtn.NameOfVideo);
            var user = _createNewUserRepository.GetById(AuthorizationPage.UserId);
            string message = $"{user.Login} deleted video {dataContextFromBtn.NameOfVideo} ";
            Log log = new Log(DateTime.Now, message);
            _createNewLogRepository.Create(log);
            _createNewVideoRepository.Delete(video);
        }
    }

}
