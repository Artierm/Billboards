using BillboardProject.Models;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Linq;
using System.Windows;

namespace BillboardProject.Presents
{
    public class RegistrationService
    {
        private readonly ICreateNewUserRepository _createNewUserRepository;
        public RegistrationService(ICreateNewUserRepository createNewUserRepository)
        {
            _createNewUserRepository = createNewUserRepository;
        }

        public bool AddNewUser(string login, string password, string passwordRepeat, out bool admin)
        {
            bool validationParameter = true;
            admin = false;
            if(password == passwordRepeat)
            {
                string salt = PasswordService.CreateSalt(10);
                string hashpassword = PasswordService.GenerateSHAHash256(password, salt);

                var users = _createNewUserRepository.GetAll();

                User user = new User(login, hashpassword, salt);
                var character = users.FirstOrDefault(c => c.Login == login);
                if (character is null)
                {
                    _createNewUserRepository.Create(user);
                }
                else
                {
                    validationParameter = false;
                    string errorMessage = FormattableString.Invariant($"This login already exists");
                    MessageBox.Show(errorMessage);
                }

                //исправить
                var users2 = _createNewUserRepository.GetAll();
                var user2 = users2.FirstOrDefault(c => c.Login == login);
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
