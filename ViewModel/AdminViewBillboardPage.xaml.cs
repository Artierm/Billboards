using BillboardProject.Service;
using DAL.Models;
using DAL.Repositories.Implementations;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardProject
{
    public partial class AdminViewBillboardPage : Page
    {
        private readonly AdminViewBillboardService _adminViewBillboardService;
        public AdminViewBillboardPage()
        {
            InitializeComponent();
            var createNewBillboardRepository = new CreateNewBillboardRepository();
            var createNewLogRepository = new CreateNewLogRepository();
            _adminViewBillboardService = new AdminViewBillboardService(createNewBillboardRepository, createNewLogRepository);
            string address = UserViewBillboardPage.BillboardAddress;
            var billboards = createNewBillboardRepository.GetAll();
            var billboard = billboards.FirstOrDefault(c => c.Address == address);
            List<Billboard> billsList = new List<Billboard>();
            billsList.Add(billboard);
            billsGrid.ItemsSource = billsList;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminBillboardsPage());
        }

        public void Button_Click_DeleteBillboard(object sender, RoutedEventArgs e)
        {
            _adminViewBillboardService.DeleteBillboard(sender);
            this.NavigationService.Navigate(new AdminBillboardsPage());
        }
    }
}
