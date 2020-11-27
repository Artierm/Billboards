using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Navigation;

namespace BillboardsProject.Presents
{
    class RegistrationPresent
    {

        public IRegistration registrationView;
        Registration registration;
        ApplicationContext Db;

        public RegistrationPresent(Registration registration, IRegistration view)
        {
            this.registration = registration;
            Db = new ApplicationContext();   //Почему здесь 
           // List<User> users = Db.Users.ToList();
            registrationView = view;
            this.registration.ValidationEvent += AddNewUser;
        }

        public void AddNewUser(object sender, EventArgs e, string login, string password, string passwordRepeat)
        {
            if(password == passwordRepeat)
            {
                User user = new User(login, password);
                Db.Add(user);
                Db.SaveChanges();
            }
            else
            {
                string errorMessage = FormattableString.Invariant($"Passwords do not match");
                MessageBox.Show(errorMessage);
            }
        }
    }
}
