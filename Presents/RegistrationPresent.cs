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
    class RegistrationPresent
    {

        public ICreateBillboard registrationView;
        Registration registration;
        Authorization authorization;

        ApplicationContext Db;

        public RegistrationPresent(Registration registration, ICreateBillboard view)
        {
            authorization =  new Authorization();
          
            this.registration = registration;
            Db = new ApplicationContext();   //Почему здесь 
            registrationView = view;
            this.registration.ValidationEvent += AddNewUser;
        }

        public bool AddNewUser(object sender, EventArgs e, string login, string password, string passwordRepeat, out bool admin)
        {
            bool validationParametr = true;
            admin = false;
            if(password == passwordRepeat)
            {
                string salt = RegistrationModel.CreateSalt(10);
                string hashpassword = RegistrationModel.GenerateSHAHash256(password, salt);
                List<User> users = Db.Users.ToList();
                User user = new User(login, hashpassword, salt);
                var character = users.Find(c => c.Login == login);
                if (character is null)
                {
                    Db.Users.Add(user);
                    Db.SaveChanges();
                }
                else
                {
                    validationParametr = false;
                    string errorMessage = FormattableString.Invariant($"This login already exists");
                    MessageBox.Show(errorMessage);
                }
                List<User> users2 = Db.Users.ToList();
                var user2 = users2.Find(c => c.Login == login);
                Authorization.IdUser = user2.Id;
                if(Authorization.IdUser == 1)
                {
                    admin = true;
                }
                //List<User> users2 = Db.Users.ToList();
                //var userAdmin = users2.Find(c => c.Id == 1);
                //if(userAdmin.Login == login)
                //{
                //    Authorization.IdUser = 1;
                //    admin = true;
                //}

            }
            else
            {
                validationParametr = false;
                string errorMessage = FormattableString.Invariant($"Passwords do not match");
                MessageBox.Show(errorMessage);
            }
            return validationParametr;
        }
    }
}
