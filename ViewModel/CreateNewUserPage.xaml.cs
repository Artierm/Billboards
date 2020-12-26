using BillboardProject.Model;
using BillboardProject.Service;
using DAL.Repositories.Implementations;
using System.Windows;
using System.Windows.Controls;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class CreateNewUserPage : Page, ICreateUsers
    {
        private readonly CreateNewUserService _createNewUserService;

        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        public string UserLogin { get => user_login.Text.Trim(); set => user_login.Text = value.Trim(); }
        public string UserPassword { get => user_password.Password.Trim(); set => user_password.Password = value.Trim(); }

        public string UserPasswordRepeat { get => user_password_repeat.Password.Trim(); set => user_password_repeat.Password = value.Trim(); }
        public CreateNewUserPage(ICreateNewLogRepository createNewLogRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository, ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewScheduleRepository createNewScheduleRepository)
        {          
            InitializeComponent();
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewVideoRepository = createNewVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewScheduleRepository = createNewScheduleRepository;
            _createNewUserService = new CreateNewUserService(_createNewUserRepository, _createNewLogRepository);
        }

        public void Button_Click_AddUser(object sender, RoutedEventArgs e)
        {
             _createNewUserService.CreateUser(UserLogin, UserPassword, UserPasswordRepeat);
            this.NavigationService.Navigate(new CrudUserPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CrudUserPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
        }
    }
}
