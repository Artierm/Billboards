using BillboardProject.Models;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Linq;
using System.Windows;

namespace BillboardProject.Service
{
    public class CreateNewUserService
    {
        private readonly ICreateNewUserRepository _createNewUserRepository;
        public CreateNewUserService(ICreateNewUserRepository createNewUserRepository)
        {
            _createNewUserRepository = createNewUserRepository;
        }

        public void CreateUser(string login, string password, string repeatPassword)
        {
            
            var users = _createNewUserRepository.GetAll();
            var newUser = users.FirstOrDefault(c => c.Login == login);
            if(newUser is null)
            {
                if (password == repeatPassword)
                {
                    var salt = PasswordService.CreateSalt(10);
                    var hashPassword = PasswordService.GenerateSHAHash256(password, salt);
                    User user = new User(login, hashPassword, salt);
                    _createNewUserRepository.Create(user);
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
