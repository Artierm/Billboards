using Billbort.Presents;
using DAL.Repositories.Implementations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Billbort
{
    public partial class CrudUserPage : Page
    {
        private CrudUserService _crudUserService;
        public CrudUserPage()
        {
            InitializeComponent();
            var createNewUserRepository = new CreateNewUserRepository();

            _crudUserService = new CrudUserService(createNewUserRepository, new CreateNewBillboardRepository());
            var users = createNewUserRepository.GetAll();
            var realUsers = users.Where(c => c.Id != 1);
            usersGrid.ItemsSource = realUsers;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
           this.NavigationService.Navigate(new AdminRoomPage());
        }

        public void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            _crudUserService.RemoveUser(sender);
            this.NavigationService.Navigate(new CrudUserPage());
        }

        public void Button_Click_AddUser(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateNewUserPage());
        }
    }
}
