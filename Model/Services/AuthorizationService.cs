using System;
using BillboardProject.Models;
using DAL.Repositories.Interfaces;
using System.Linq;
using DAL.Models;

namespace BillboardProject.Service
{
    public class AuthorizationService
    {
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        public AuthorizationService(ICreateNewUserRepository createNewUserRepository, ICreateNewLogRepository createNewLogRepository)
        {
            _createNewUserRepository = createNewUserRepository;
            _createNewLogRepository = createNewLogRepository;
        }

        public bool CheckUser(string login, string password, out bool isAdmin, out int userId)
        {
            isAdmin = false;

            var users = _createNewUserRepository.GetAll();

            var checkedUser = users.FirstOrDefault(c => c.Login == login);
            userId = 0;
            if (checkedUser is null)
            {
                return false;
            }

            if (checkedUser.Id == 1)
            {
                isAdmin = true;
            }

            userId = checkedUser.Id;
            var checkpassword = PasswordService.GenerateSHAHash256(password, checkedUser.Salt);
            if (checkpassword == checkedUser.Password)
            {
                string message = $"{login} successful authorization";
                Log log = new Log(DateTime.Now, message);
                _createNewLogRepository.Create(log);
                return true;
            }
            else
            {
                string message = $"{login} authorization error ";
                Log log = new Log(DateTime.Now, message);
                _createNewLogRepository.Create(log);
                return false;
            }
        }
    }
}
