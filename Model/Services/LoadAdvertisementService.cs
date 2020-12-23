using System;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace BillboardProject.Service
{
    public class LoadAdvertisementService
    {
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;

        private readonly ICreateNewLogRepository _createNewLogRepository;
        public LoadAdvertisementService(ICreateNewVideoRepository createNewVideoRepository, ICreateNewLogRepository createNewLogRepository,  ICreateNewUserRepository  createNewUserRepository)
        {
            _createNewVideoRepository = createNewVideoRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewUserRepository = createNewUserRepository;
        }

        public void LoadVideo(string nameOfVideo, int timeOfVideo)
        {
            Video video = new Video(nameOfVideo, timeOfVideo, AuthorizationPage.UserId);
            _createNewVideoRepository.Create(video);
            var user = _createNewUserRepository.GetById(AuthorizationPage.UserId);
            string message = $"{user.Login} loaded new video {nameOfVideo}";
            Log log = new Log(DateTime.Now, message);
            _createNewLogRepository.Create(log);
        }
    }
}
