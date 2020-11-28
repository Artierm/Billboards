using BillboardsProject.Presents;
using BillboardsProject.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BillboardsProject
{
    public partial class Registration : Page, IRegistration
    {
        public  delegate bool ValidationDelegate(object sender, EventArgs e, string login, string password, string passwordRepeat);
        public  event EventHandler AutorizationEvent;
        public  event ValidationDelegate ValidationEvent;
        public IRegistration iregistration;

        public string RegistrationLogin { get => textBoxLogin.Text.Trim(); set => textBoxLogin.Text = value.Trim(); }
        public string RegistrationPassword { get => pass_box.Password.Trim(); set => pass_box.Password = value.Trim(); }
        public string RegistrationPasswordRepeat { get => pass_box2.Password.Trim(); set => pass_box2.Password = value.Trim(); }

        public Registration(IRegistration ireg)
        {
            this.iregistration = ireg;
            InitializeComponent();
            RegistrationPresent registrationPresent = new RegistrationPresent(this,this.iregistration);
        }

        public   void Button_Click_Authorization(object sender, RoutedEventArgs e)
        {
            //AutorizationEvent.Invoke();
            this.NavigationService.Navigate(new Authorization());

        }

        private void Button_Click_Validation(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                if (ValidationEvent.Invoke(sender, e, RegistrationLogin, RegistrationPassword, RegistrationPasswordRepeat))
                {
                    this.NavigationService.Navigate(new UserRoom());
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
