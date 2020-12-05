using DAL.Models;
using DAL.Repositories.Interfaces;

namespace BillboardProject.Service
{
    public class LoadAdvertisementService
    {
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        public LoadAdvertisementService(ICreateNewVideoRepository createNewVideoRepository)
        {
            _createNewVideoRepository = createNewVideoRepository;
        }

        public void LoadVideo(string nameOfVideo, int timeOfVideo)
        {
            Video video = new Video(nameOfVideo, timeOfVideo, AuthorizationPage.UserId);
            _createNewVideoRepository.Create(video);
        }
    }
}
