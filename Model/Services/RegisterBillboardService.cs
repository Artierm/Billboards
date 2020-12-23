using System;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Linq;
using System.Windows.Controls;

namespace BillboardProject.Service
{
    public class RegisterBillboardService
    {
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        public RegisterBillboardService(ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewUserRepository createNewUserRepository,  ICreateNewLogRepository createNewLogRepository)
        {
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewLogRepository = createNewLogRepository;
        }

        public void RegisterBillboard(object sender)
        {
            var billboards = _createNewBillboardRepository.GetAll();
            var users = _createNewUserRepository.GetAll();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (Billboard)btnSender.DataContext;
            var billboard = billboards.FirstOrDefault(c => c.Id == dataContextFromBtn.Id);
            var owner = users.FirstOrDefault(c => c.Id == AuthorizationPage.UserId);
            billboard.Owner = owner.Login;

            string message = $"{owner.Login} registered billboard {dataContextFromBtn.Address}";
            Log log = new Log(DateTime.Now, message);
            _createNewLogRepository.Create(log);

            _createNewBillboardRepository.Update(billboard);
            //_database.SaveChanges();
        }
    }
}
