using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BillboardProject;
using DAL.Models;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace BillboardsProject.View
{
    /// <summary>
    /// Interaction logic for ViewUserSchedulePage.xaml
    /// </summary>
    public partial class ViewUserSchedulePage : Page
    {
        public static List<Video> ScheduleAndVideos;

        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        public ViewUserSchedulePage(ICreateNewLogRepository createNewLogRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository, ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewScheduleRepository createNewScheduleRepository)
        {
            InitializeComponent();
            videosGrid.ItemsSource = ScheduleAndVideos;
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewVideoRepository = createNewVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewScheduleRepository = createNewScheduleRepository;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SchedulePage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }
    }
}
