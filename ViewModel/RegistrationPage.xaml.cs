using BillboardProject.Model;
using BillboardProject.Service;
using DAL.Repositories.Implementations;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class RegistrationPage : Page, ICreateBillboard, ITime
    {
        private readonly RegistrationService _registrationService;
        public string RegistrationLogin { get => textBoxLogin.Text.Trim(); set => textBoxLogin.Text = value.Trim(); }
        public string RegistrationPassword { get => pass_box.Password.Trim(); set => pass_box.Password = value.Trim(); }
        public string RegistrationPasswordRepeat { get => pass_box2.Password.Trim(); set => pass_box2.Password = value.Trim(); }
        public string Time { get => time.Text; set => time.Text = value.ToString(); }

        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;

        public RegistrationPage(ICreateNewLogRepository createNewLogRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository, ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewScheduleRepository createNewScheduleRepository)
        {
            InitializeComponent();
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewVideoRepository = createNewVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewScheduleRepository = createNewScheduleRepository;
            _registrationService = new RegistrationService(_createNewUserRepository, _createNewLogRepository);
        }

        public   void Button_Click_Authorization(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AuthorizationPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }

        private void Button_Click_Register(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                if (_registrationService.AddNewUser(RegistrationLogin, RegistrationPassword, RegistrationPasswordRepeat, out bool admin))
                {
                    if (admin)
                    {
                        this.NavigationService.Navigate(new AdminRoomPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
                    }
                    else
                    {
                        this.NavigationService.Navigate(new UserRoomPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
                    }
                }
            }
       
        }

        public bool Validation()
        {
            bool validationParametr = true;
            RegistrationLogin = textBoxLogin.Text;
            RegistrationPassword = pass_box.Password;
            RegistrationPasswordRepeat = pass_box2.Password;
            string login = RegistrationLogin;
            string password = RegistrationPassword;
            string passwordRepeat = RegistrationPasswordRepeat;

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Некорректный логин";
                textBoxLogin.Background = Brushes.IndianRed;
                validationParametr = false;
            }
            else if (password.Length < 7)
            {
                pass_box.ToolTip = "Некорректный пароль";
                pass_box.Background = Brushes.IndianRed;
                validationParametr = false;
            }
            else if (password != passwordRepeat)
            {
                pass_box2.ToolTip = "Некорректный пароль";
                pass_box2.Background = Brushes.IndianRed;
                validationParametr = false;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.White;
                pass_box.ToolTip = "";
                textBoxLogin.Background = Brushes.White;
                pass_box2.ToolTip = "";
                textBoxLogin.Background = Brushes.White;
                validationParametr = true;
            }
            return validationParametr;
        }
    }
}
