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

        public ICreateBillboard registrationView;
        RegistrationPage registration;
        AuthorizationPage authorization;

        DatabaseContext database;
        public RegistrationPresenter(RegistrationPage registration, ICreateBillboard view)
        {
            authorization =  new AuthorizationPage();
            database = new DatabaseContext();

            this.registration = registration;
            
            registrationView = view;
            this.registration.ValidationEvent += AddNewUser;
        }

        public bool AddNewUser(object sender, EventArgs e, string login, string password, string passwordRepeat, out bool admin)
        {
            bool validationParameter = true;
            admin = false;
            if(password == passwordRepeat)
            {
                string salt = RegistrationModel.CreateSalt(10);
                string hashpassword = RegistrationModel.GenerateSHAHash256(password, salt);
                List<User> users = database.Users.ToList();
                User user = new User(login, hashpassword, salt);
                var character = users.Find(c => c.Login == login);
                if (character is null)
                {
                    database.Users.Add(user);
                    database.SaveChanges();
                }
                else
                {
                    validationParameter = false;
                    string errorMessage = FormattableString.Invariant($"This login already exists");
                    MessageBox.Show(errorMessage);
                }
                List<User> users2 = database.Users.ToList();
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
