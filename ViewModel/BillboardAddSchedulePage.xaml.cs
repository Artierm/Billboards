using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BillboardProject;
using DAL.Repositories.Interfaces;

namespace BillboardsProject.View
{
    /// <summary>
    /// Interaction logic for BillboardAddSchedulePage.xaml
    /// </summary>
    public partial class BillboardAddSchedulePage : Page
    {
        private ICreateNewScheduleRepository _createNewScheduleRepository;
        private ICreateNewUserRepository _createNewUserRepository;
        public BillboardAddSchedulePage(ICreateNewScheduleRepository сreateNewScheduleRepository, ICreateNewUserRepository createNewUserRepository)
        {
            InitializeComponent();
            _createNewScheduleRepository = сreateNewScheduleRepository;
            _createNewUserRepository = createNewUserRepository;
            var user = _createNewUserRepository.GetById(AuthorizationPage.UserId);
            var schedules =  _createNewScheduleRepository.GetAll();
            var workSchedules = schedules.Where(c => c.User == user);
            schedulesGrid.ItemsSource = workSchedules;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserBillboardsPage());
        }
    }
}
