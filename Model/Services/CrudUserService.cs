using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Linq;
using System.Windows.Controls;

namespace BillboardProject.Service
{
    public class CrudUserService
    {
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        public CrudUserService(ICreateNewUserRepository createNewUserRepository, ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewLogRepository createNewLogRepository)
        {
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewLogRepository = createNewLogRepository;
        }

        public void RemoveUser(object sender)
        {
            var billboards = _createNewBillboardRepository.GetAll();
            var users = _createNewUserRepository.GetAll();

            Button btnSender = (Button)sender;
            var dataContextFromBtn = (User)btnSender.DataContext;
            var user = users.FirstOrDefault(c => c.Id == dataContextFromBtn.Id);
            var removeBillboards = billboards.Where(c => c.Owner == dataContextFromBtn.Login);
        
            foreach(var billboard in removeBillboards)
            {
                billboard.Owner = string.Empty;
            }
            string message = $"Admin delete user {dataContextFromBtn.Login}";
            Log log = new Log(DateTime.Now, message);
            _createNewLogRepository.Create(log);
            _createNewUserRepository.Delete(user);
        }

        public void CreateUser(object sender, EventArgs e)
        {         
            var users = _createNewUserRepository.GetAll();

            Button btnSender = (Button)sender;
            var dataContextFromBtn = (User)btnSender.DataContext;
            var user = users.FirstOrDefault(c => c.Id == dataContextFromBtn.Id);

            _createNewUserRepository.Create(user); //  _createNewUserRepository.Delete(user);
        }
    }
}
