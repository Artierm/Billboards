using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace BillboardsProject.Presents
{
    class AuthorizationPresent
    {
        public IAuthorization authorizationView;
        public IRegistration registrationView;
        Authorization authorization;
        ApplicationContext Db;
        public AuthorizationPresent(Authorization authorization)
        {
            this.authorization = authorization;
            Db = new ApplicationContext(); //зачем
            //authorization.AdminEvent += ;
            this.authorization.RegistrationEvent += Registration;
        }

        public void Registration(object sender, EventArgs e)
        {
           this.authorization.NavigationService.Navigate(new Registration(registrationView));
        }
    }
    
}
