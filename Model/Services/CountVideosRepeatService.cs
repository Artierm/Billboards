//using System;
//using System.Windows.Controls;
//using DAL.Context;
//using DAL.Models;
//using DAL.Repositories.Interfaces;

//namespace BillboardProject.Model.Services
//{
//    public class CountVideosRepeatService
//    {
//        private readonly ICreateNewCountVideosRepeatRepository _createNewCountVideosRepeatRepository;

//        private readonly ICreateNewUserRepository _createNewUserRepository;

//        private readonly ICreateNewLogRepository _createNewLogRepository;

//        private readonly ICreateNewVideoRepository _createNewVideoRepository;
//        public CountVideosRepeatService(ICreateNewUserRepository createNewUserRepository, ICreateNewLogRepository createNewLogRepository, ICreateNewCountVideosRepeatRepository createNewCountVideosRepeatRepository, ICreateNewVideoRepository createNewVideoRepository)
//        {
//            _createNewLogRepository = createNewLogRepository;
//            _createNewUserRepository = createNewUserRepository;
//            _createNewCountVideosRepeatRepository = createNewCountVideosRepeatRepository;
//            _createNewVideoRepository = createNewVideoRepository;
//        }

//        public void SaveCountOfRepeats(object sender)
//        {
//            Button btnSender = (Button)sender;
//            var dataVideoFromBtn = (Video)btnSender.DataContext;
//            var dataCountVideosRepeatFromBtn = (Video)btnSender.DataContext;
//            var user = _createNewUserRepository.GetById(AuthorizationPage.UserId);
//            var countOfRepeat = dataCountVideosRepeatFromBtn.TimeOfVideo;
//            CountVideosRepeat countVideos = new CountVideosRepeat(dataVideoFromBtn.NameOfVideo,user,countOfRepeat);
//            _createNewCountVideosRepeatRepository.Create(countVideos);

//            string message = $"{user.Login} added count of repeats {dataVideoFromBtn.NameOfVideo}";
//            Log log = new Log(DateTime.Now, message);
//            _createNewLogRepository.Create(log);
//        }

//    }
//}
