using BillboardsProject.Models;
using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;

namespace BillboardsProject.Presenter
{
    class AuthorizationPresenter
    {

        private DatabaseContext _database;
        public AuthorizationPresenter()
        {
            _database = new DatabaseContext();
        }

        public bool CheckUser(string login, string password, out bool isAdmin, out int userId)
        {
            isAdmin = false;
            List<User> users = _database.Users.ToList();
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
