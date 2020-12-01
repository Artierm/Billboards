using BillboardsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace BillboardsProject.Presents
{
    class CreateNewUserPresenter
    {
        private DatabaseContext _database;
        public CreateNewUserPresenter()
        {
            _database = new DatabaseContext();
        }

        public void CreateUser(string login, string password, string repeatPassword)
        {
            List<User> users = _database.Users.ToList();
            var newUser = users.Find(c => c.Login == login);
            if(newUser is null)
            {
                if (password == repeatPassword)
                {
                    var salt = RegistrationModel.CreateSalt(10);
                    var hashPassword = RegistrationModel.GenerateSHAHash256(password, salt);
                    User user = new User(login, hashPassword, salt);
                    _database.Users.Add(user);
                    _database.SaveChanges();
                }
                else
                {
                    string errorMessage = FormattableString.Invariant($"Passwords do not match");
                    MessageBox.Show(errorMessage);
                }
            }
            else
            {
                string errorMessage = FormattableString.Invariant($"This login already exists");
                MessageBox.Show(errorMessage);
            }
           
        }
    }
}
