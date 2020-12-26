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

        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;

        public static int BillboardId { get; set; }
        public static string BillboardOwner { get; set; }
        public static string BillboardAddress { get; set; }

        public UserViewBillboardPage(ICreateNewVideoRepository createNewVideoRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleRepository createNewScheduleRepository)
        {
            InitializeComponent();
            _createNewVideoRepository = createNewVideoRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewScheduleRepository = createNewScheduleRepository;

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
            this.NavigationService.Navigate(new UserBillboardsPage(new CreateNewBillboardRepository(), new CreateNewScheduleRepository() , new CreateNewScheduleAndVideoRepository(), new CreateNewUserRepository(), new CreateNewVideoRepository()));
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
