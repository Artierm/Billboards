using Billbort.Models;
using DAL.Repositories.Interfaces;
using System.Linq;

namespace Billbort.Presenter
{
    public class AuthorizationService
    {
        private readonly ICreateNewUserRepository _createNewUserRepository;
        public AuthorizationService(ICreateNewUserRepository createNewUserRepository)
        {
            _createNewUserRepository = createNewUserRepository;
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
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
