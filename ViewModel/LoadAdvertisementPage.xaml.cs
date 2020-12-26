using BillboardProject.Model;
using BillboardProject.Service;
using DAL.Repositories.Implementations;
using System;
using System.Windows;
using System.Windows.Controls;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class LoadAdvertisementPage : Page, ILoadAdvertisement
    {
        private readonly LoadAdvertisementService _loadAdvertisementService;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        public string LoadAdvertisementNameVideo { get => name_video.Text.Trim(); set => name_video.Text = value.Trim(); }
        public int LoadAdvertisementTimeVideo { get => Convert.ToInt32(time_video.Text.Trim()); set => time_video.Text = value.ToString().Trim(); }
        public LoadAdvertisementPage(ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleRepository createNewScheduleRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository, ICreateNewLogRepository createNewLogRepository)
        {
            InitializeComponent();
            _createNewVideoRepository = createNewVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewLogRepository = createNewLogRepository;
            _loadAdvertisementService = new LoadAdvertisementService(_createNewVideoRepository, _createNewLogRepository, _createNewUserRepository);
        }
        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdvertisementPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }

        public void Button_LoadVideo(object sender, RoutedEventArgs e)
        {
           _loadAdvertisementService.LoadVideo(LoadAdvertisementNameVideo, LoadAdvertisementTimeVideo);
            this.NavigationService.Navigate(new AdvertisementPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }
    }
}
