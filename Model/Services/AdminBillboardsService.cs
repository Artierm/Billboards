using System;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Windows.Controls;

namespace BillboardProject.Service
{
    public class AdminBillboardsService
    {
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        public AdminBillboardsService(ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewLogRepository createNewLogRepository, ICreateNewUserRepository createNewUserRepository)
        {
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewUserRepository = createNewUserRepository;
        }

        public void ViewBillboard(object sender, out int id, out string address, out string owner)
        {

            Button btnSender = (Button)sender;
            var dataContextFromButton = (DAL.Models.Billboard)btnSender.DataContext;

            address = dataContextFromButton.Address;
            id = dataContextFromButton.Id;
            owner = dataContextFromButton.Owner;

            var user = _createNewUserRepository.GetById(AuthorizationPage.UserId);
            string message = $"{user.Login} looked at billboard {address}";
            Log log = new Log(DateTime.Now, message);
            _createNewLogRepository.Create(log);
        }
    }
}
