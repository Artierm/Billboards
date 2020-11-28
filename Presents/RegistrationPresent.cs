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
        ApplicationContext Db;

        public RegistrationPresent(Registration registration, ICreateBillboard view)
        {
            this.registration = registration;
            Db = new ApplicationContext();   //Почему здесь 
            registrationView = view;
            this.registration.ValidationEvent += AddNewUser;
        }

        public bool AddNewUser(object sender, EventArgs e, string login, string password, string passwordRepeat)
        {
            bool validationParametr = true;
            if(password == passwordRepeat)
            {
                string salt = RegistrationModel.CreateSalt(10);
                string hashpassword = RegistrationModel.GenerateSHAHash256(password, salt);
                List<User> users = Db.Users.ToList();
                User user = new User(login, hashpassword, salt);
                var character = users.Find(c => c.Login == login);
                if (character is null)
                {
                    Db.Add(user);
                    Db.SaveChanges();
                }
                else
                {
                    validationParametr = false;
                    string errorMessage = FormattableString.Invariant($"This login already exists");
                    MessageBox.Show(errorMessage);
                }
                var characterId = users.Find(c => c.Login == login);
                Authorization.IdUser = character.Id;               
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
