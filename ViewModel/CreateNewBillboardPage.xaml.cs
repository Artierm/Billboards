using BillboardProject.Presents;
using BillboardProject.ViewModel;
using DAL.Repositories.Implementations;
using System.Windows;
using System.Windows.Controls;

namespace BillboardProject
{
    public partial class CreateNewBillboardPage : Page, IRegistration
    {
        private readonly CreateNewBillboardService _createNewBillboardService;

        public string BillboardCreateAddress { get => billboard_address.Text.Trim(); set => billboard_address.Text = value.Trim(); }
        public CreateNewBillboardPage()
        {
            InitializeComponent();
            _createNewBillboardService = new CreateNewBillboardService(new CreateNewBillboardRepository());
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminBillboardsPage());
        }
        public void Button_Click_AddBillboard(object sender, RoutedEventArgs e)
        {
            _createNewBillboardService.AddBillboard(BillboardCreateAddress);
            this.NavigationService.Navigate(new AdminBillboardsPage());
        }
    }
}
