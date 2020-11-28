using BillboardsProject.Models;
using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;

namespace BillboardsProject.Presents
{
    class AuthorizationPresent
    {
        public IAuthorization authorizationView;
        public ICreateBillboard registrationView;
        Authorization authorization;
        ApplicationContext Db;
        public AuthorizationPresent(Authorization authorization)
        {
            this.authorization = authorization;
            Db = new ApplicationContext(); //зачем
            //authorization.AdminEvent += ;
            this.authorization.RegistrationEvent += Registration;
            this.authorization.UserEvent += CheckUser;
        }

        public void Registration(object sender, EventArgs e)
        {
           this.authorization.NavigationService.Navigate(new Registration(registrationView));
        }

        public bool CheckUser(object sender, EventArgs e, string login, string password, out bool admin, out int idUser)
        {        
            bool authorizationCheck = false;
            admin = false;
            List<User> users = Db.Users.ToList();
            var checkuser = users.Find(c => c.Login == login);
            idUser = 0;
            if(checkuser is null)
            {
                return false;
            }
            if(checkuser.Id == 1)
            {
                admin = true;
            }
            idUser = checkuser.Id;
            var checkpassword = RegistrationModel.GenerateSHAHash256(password, checkuser.Salt);
            if(checkpassword == checkuser.Password)
            {
                authorizationCheck = true;
            }
            return authorizationCheck;
        }
    }
    
}
