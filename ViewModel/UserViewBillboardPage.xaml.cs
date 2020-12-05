using Billbort.Presents;
using DAL.Context;
using DAL.Models;
using DAL.Repositories.Implementations;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Billbort
{
    public partial class UserViewBillboardPage : Page
    {

        private DatabaseContext database;
        private UserViewBillboardService _userViewBillboardService;
        public static int BillboardId { get; set; }
        public static string BillboardOwner { get; set; }
        public static string BillboardAddress { get; set; }

        public UserViewBillboardPage()
        {
            InitializeComponent();
            var createNewBillboardRepository = new CreateNewBillboardRepository();

            _userViewBillboardService = new UserViewBillboardService();
            string address = UserViewBillboardPage.BillboardAddress;
            var billboards = createNewBillboardRepository.GetAll();
            var billboard = billboards.FirstOrDefault(c => c.Address == address);
            List<Billboard> billsList = new List<Billboard>();

            billsList.Add(billboard);
            billsGrid.ItemsSource = billsList;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserBillboardsPage());
        }

        public void Button_Click_View_Billboard(object sender, RoutedEventArgs e)
        {
            _userViewBillboardService.ViewBillboard(sender, out int id, out string address, out string owner);
        }

    }
}
