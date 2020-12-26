using BillboardProject.Service;
using System;
using System.Windows;
using System.Windows.Controls;
using BillboardProject.Model;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class AuthorizationPage : Page, IAuthorization
    {
        private readonly AuthorizationService _authorizationService;

        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        public static int UserId { get; set; }

        public string AuthorizationLogin { get => authorization_login.Text.Trim(); set => authorization_login.Text = value.Trim(); }
        public string AuthorizationPassword { get => authorization_password.Password.Trim(); set => authorization_password.Password = value.Trim(); }
        public AuthorizationPage(ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleRepository createNewScheduleRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository, ICreateNewLogRepository createNewLogRepository)
        {
            InitializeComponent();
            _createNewScheduleRepository = createNewScheduleRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewVideoRepository = createNewVideoRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewBillboardRepository = createNewBillboardRepository;
            _authorizationService = new AuthorizationService(_createNewUserRepository, _createNewLogRepository);
        }

        public void Button_Click_Log_In(object sender, RoutedEventArgs e)
        {
            if (_authorizationService.CheckUser(AuthorizationLogin, AuthorizationPassword, out bool admin, out int userId))
            {
                if (admin)
                {
                    this.NavigationService.Navigate(new AdminRoomPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
                }
                else
                {
                    this.NavigationService.Navigate(new UserRoomPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
                }
                UserId = userId;
            }
            else
            {
                string errorMessage = FormattableString.Invariant($"Password or login is incorrect");
                MessageBox.Show(errorMessage);
            }
        }

        public void Button_Click_Registration(object sender, RoutedEventArgs e)
        {
           this.NavigationService.Navigate(new RegistrationPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
        }
    }
}
