using BillboardProject.Service;
using DAL.Models;
using DAL.Repositories.Implementations;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BillboardsProject.Model.Services;
using BillboardsProject.View;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class UserViewBillboardPage : Page
    {
        private readonly UserViewBillboardService _userViewBillboardService;
        private readonly NowPlayingService _nowPlayingService;

        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;

        public static int BillboardId { get; set; }
        public static string BillboardOwner { get; set; }
        public static string BillboardAddress { get; set; }

        public UserViewBillboardPage(ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleRepository createNewScheduleRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository, ICreateNewLogRepository createNewLogRepository)
        {
            InitializeComponent();
            _createNewScheduleRepository = createNewScheduleRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewVideoRepository = createNewVideoRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewBillboardRepository = createNewBillboardRepository;

            _userViewBillboardService = new UserViewBillboardService();
            _nowPlayingService = new NowPlayingService(_createNewVideoRepository,_createNewScheduleAndVideoRepository, _createNewBillboardRepository, _createNewScheduleRepository);
            string address = UserViewBillboardPage.BillboardAddress;
            var billboards = _createNewBillboardRepository.GetAll();
            var billboard = billboards.FirstOrDefault(c => c.Address == address);
            List<Billboard> billsList = new List<Billboard>();

            billsList.Add(billboard);
            billsGrid.ItemsSource = billsList;
        }
        
        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserBillboardsPage(_createNewBillboardRepository,_createNewScheduleRepository,_createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }

        public void Button_Click_View_Video(object sender, RoutedEventArgs e)
        {
            _nowPlayingService.ContextBillboard(sender, out Billboard billboard);
            NowPlaying.Billboard = billboard;
            NowPlayingService.NowPlay =  _nowPlayingService.NowPlayVideoTime();
            MessageBox.Show(NowPlayingService.NowPlay);
        }

    }
}
