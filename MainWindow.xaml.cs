using BillboardsProject.Presents;
using System.Windows;

namespace BillboardsProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Loaded += MyWindow_Loaded;
            InitializeComponent();
            //AuthorizationPresent authorizationPresent = new AuthorizationPresent();
            //RegistrationPresent registrationPresent = new RegistrationPresent();
        }

        public void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Authorization());
        }

    }
}
