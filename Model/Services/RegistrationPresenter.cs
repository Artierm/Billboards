using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using BillboardsProject.Models;

namespace BillboardsProject.Presents
{
    class RegistrationPresenter
    {
        private DatabaseContext _database;
        public RegistrationPresenter()
        {
            _database = new DatabaseContext();
        }

        public bool AddNewUser(string login, string password, string passwordRepeat, out bool admin)
        {
            bool validationParameter = true;
            admin = false;
            if(password == passwordRepeat)
            {
                string salt = RegistrationModel.CreateSalt(10);
                string hashpassword = RegistrationModel.GenerateSHAHash256(password, salt);
                List<User> users = _database.Users.ToList();
                User user = new User(login, hashpassword, salt);
                var character = users.Find(c => c.Login == login);
                if (character is null)
                {
                    _database.Users.Add(user);
                    _database.SaveChanges();
                }
                else
                {
                    validationParameter = false;
                    string errorMessage = FormattableString.Invariant($"This login already exists");
                    MessageBox.Show(errorMessage);
                }
                List<User> users2 = _database.Users.ToList();
                var user2 = users2.Find(c => c.Login == login);
                AuthorizationPage.UserId = user2.Id;
                if(AuthorizationPage.UserId == 1)
                {
                    admin = true;
                }
            }
            else
            {
                validationParameter = false;
                string errorMessage = FormattableString.Invariant($"Passwords do not match");
                MessageBox.Show(errorMessage);
            }
            return validationParameter;
        }
    }
}
