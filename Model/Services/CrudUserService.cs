using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Linq;
using System.Windows.Controls;

namespace BillboardProject.Presents
{
    public class CrudUserService
    {
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        public CrudUserService(ICreateNewUserRepository createNewUserRepository, ICreateNewBillboardRepository createNewBillboardRepository)
        {
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewUserRepository = createNewUserRepository;
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

            _createNewUserRepository.Delete(user);
        }

        public void CreateUser(object sender, EventArgs e)
        {         
            var users = _createNewUserRepository.GetAll();

            Button btnSender = (Button)sender;
            var dataContextFromBtn = (User)btnSender.DataContext;
            var user = users.FirstOrDefault(c => c.Id == dataContextFromBtn.Id);

            _createNewUserRepository.Delete(user);
        }
    }
}
