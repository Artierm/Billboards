using Billbort.Presents;
using DAL.Repositories.Implementations;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Billbort
{
    public partial class RegisterBillboardPage : Page
    { 
        private RegisterBillboardService _registerBillboardService;

        public RegisterBillboardPage()
        {
            InitializeComponent();
            var createNewBillboardRepository = new CreateNewBillboardRepository();

            _registerBillboardService = new RegisterBillboardService(createNewBillboardRepository, new CreateNewUserRepository()); ;
            var billboards = createNewBillboardRepository.GetAll();
            var newBillboards = billboards.Where(c => c.Owner == string.Empty);
            billsGrid.ItemsSource = newBillboards;
        }
        public void Button_Click_Register_Billboard(object sender, RoutedEventArgs e)
        {
            _registerBillboardService.RegisterBillboard(sender);
            this.NavigationService.Navigate(new UserBillboardsPage());
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserBillboardsPage());
        }       
    }
}
