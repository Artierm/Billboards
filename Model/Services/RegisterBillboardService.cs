using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Billbort.Presents
{
    public class RegisterBillboardService
    {
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        public RegisterBillboardService(ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewUserRepository createNewUserRepository)
        {
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewUserRepository = createNewUserRepository;
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
            _createNewBillboardRepository.Update(billboard);
            //_database.SaveChanges();
        }
    }
}
