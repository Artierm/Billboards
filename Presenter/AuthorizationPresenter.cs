using BillboardsProject.Models;
using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;

namespace BillboardsProject.Presents
{
    class AuthorizationPresenter
    {
        public IAuthorization authorizationView;
        public ICreateBillboard registrationView;
        AuthorizationPage authorization;
        DatabaseContext Db;
        public AuthorizationPresenter(AuthorizationPage authorization)
        {
            this.authorization = authorization;
            Db = new DatabaseContext();

            this.authorization.RegistrationEvent += Registration;
            this.authorization.UserEvent += CheckUser;
        }

        public void Registration(object sender, EventArgs e)
        {
           this.authorization.NavigationService.Navigate(new RegistrationPage(registrationView));
        }

        public bool CheckUser(object sender, EventArgs e, string login, string password, out bool isAdmin, out int userId)
        {
            isAdmin = false;
            List<User> users = Db.Users.ToList();
            var checkedUser = users.Find(c => c.Login == login);

            userId = 0;

            if (checkedUser is null)
            {
                return false;
            }

            if (checkedUser.Id == 1)
            {
                isAdmin = true;
            }

            userId = checkedUser.Id;
            var checkpassword = RegistrationModel.GenerateSHAHash256(password, checkedUser.Salt);
            if (checkpassword == checkedUser.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}
