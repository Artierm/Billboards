using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BillboardProject;
using BillboardsProject.Model.Services;
using DAL.Models;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace BillboardsProject.View
{
    public partial class NowPlaying : Page
    {
        private readonly NowPlayingService _nowPlayingService;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        public static Billboard Billboard { get; set; }

        public NowPlaying(ICreateNewLogRepository createNewLogRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository, ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewScheduleRepository createNewScheduleRepository)
        {
            InitializeComponent();
            _nowPlayingService = new NowPlayingService(new CreateNewVideoRepository(), new CreateNewScheduleAndVideoRepository(), new CreateNewBillboardRepository(), new CreateNewScheduleRepository());
            NowPlayingService.NowPlay =  _nowPlayingService.NowPlayVideoTime();
            _createNewVideoRepository = createNewVideoRepository;
            var video = _createNewVideoRepository.GetByName(NowPlayingService.NowPlay);
            List<Video> videos = new List<Video> {video};
            MessageBox.Show(video.NameOfVideo);
            nowPlayGrid.ItemsSource = videos;

            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewVideoRepository = createNewVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewScheduleRepository = createNewScheduleRepository;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserViewBillboardPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }
    }
}
