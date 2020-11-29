using BillboardsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace BillboardsProject.Presents
{
    class CreateNewUserPresent
    {
        public CreateNewUser createNewUser;
        ApplicationContext database;
        public CreateNewUserPresent(CreateNewUser createNewUser)
        {
            this.createNewUser = createNewUser;
            database = new ApplicationContext();
            this.createNewUser.AddNewUserEvent += CreateUser;
        }

        public void CreateUser(object sender, EventArgs e, string login, string password, string repeatPassword)
        {
            List<User> users = database.Users.ToList();
            var newUser = users.Find(c => c.Login == login);
            if(newUser is null)
            {
                if (password == repeatPassword)
                {
                    var salt = RegistrationModel.CreateSalt(10);
                    var hachPassword = RegistrationModel.GenerateSHAHash256(password, salt);
                    User user = new User(login, hachPassword, salt);
                    database.Users.Add(user);
                    database.SaveChanges();
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
