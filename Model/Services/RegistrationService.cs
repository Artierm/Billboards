using BillboardProject.Models;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Linq;
using System.Windows;

namespace BillboardProject.Service
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

                User registrationUser = new User(login, hashpassword, salt);
                var character = users.FirstOrDefault(c => c.Login == login);
                if (character is null)
                {
                    _createNewUserRepository.Create(registrationUser);
                }
                else
                {
                    validationParameter = false;
                    string errorMessage = FormattableString.Invariant($"This login already exists");
                    MessageBox.Show(errorMessage);
                }

                var usersUpdated = _createNewUserRepository.GetAll();
                var authorizationUser = usersUpdated.FirstOrDefault(c => c.Login == login);
                AuthorizationPage.UserId = authorizationUser.Id;
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
