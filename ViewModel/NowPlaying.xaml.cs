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
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        public static Billboard Billboard { get; set; }

        public NowPlaying(ICreateNewVideoRepository createNewVideoRepository)
        {
            InitializeComponent();
            _nowPlayingService = new NowPlayingService(new CreateNewVideoRepository(), new CreateNewScheduleAndVideoRepository(), new CreateNewBillboardRepository(), new CreateNewScheduleRepository());
            NowPlayingService.NowPlay =  _nowPlayingService.NowPlayVideoTime();
            _createNewVideoRepository = createNewVideoRepository;
            var video = _createNewVideoRepository.GetByName(NowPlayingService.NowPlay);
            List<Video> videos = new List<Video> {video};
            MessageBox.Show(video.NameOfVideo);
            nowPlayGrid.ItemsSource = videos;

        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserViewBillboardPage(new CreateNewVideoRepository(), new CreateNewScheduleAndVideoRepository(), new CreateNewBillboardRepository(), new CreateNewScheduleRepository()));
        }
    }
}
