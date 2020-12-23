using BillboardProject.Service;
using DAL.Repositories.Implementations;
using System.Windows;
using System.Windows.Controls;

namespace BillboardProject
{
    public partial class AdminBillboardsPage : Page
    {
        private  readonly AdminBillboardsService _adminBillboardsService;

        public AdminBillboardsPage()
        {
            InitializeComponent();
            var createNewBillboardRepository = new CreateNewBillboardRepository();
            var createNewLogRepository = new CreateNewLogRepository();
            var createNewUserRepository = new CreateNewUserRepository();
            _adminBillboardsService = new AdminBillboardsService(createNewBillboardRepository,createNewLogRepository, createNewUserRepository);
            var billboards = createNewBillboardRepository.GetAll();
            billsGrid.ItemsSource = billboards;
        }

        private void Button_Click_ViewBillboard(object sender, RoutedEventArgs e)
        {
            _adminBillboardsService.ViewBillboard(sender, out int id, out string address, out string owner);
            UserViewBillboardPage.BillboardAddress = address;
            UserViewBillboardPage.BillboardId = id;
            UserViewBillboardPage.BillboardOwner = owner;
            this.NavigationService.Navigate(new AdminViewBillboardPage());
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminRoomPage());
        }

        private void Button_Click_CreateNewBillboard(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateNewBillboardPage());
        }
    }
}
