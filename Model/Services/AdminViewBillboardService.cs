using System;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Linq;
using System.Windows.Controls;

namespace BillboardProject.Service
{
    public class AdminViewBillboardService
    {
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        public AdminViewBillboardService(ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewLogRepository createNewLogRepository)
        {
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewLogRepository = createNewLogRepository;
        }

        public void DeleteBillboard(object sender)
        {
            var billboards = _createNewBillboardRepository.GetAll();
          
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (DAL.Models.Billboard)btnSender.DataContext;
            DAL.Models.Billboard billboard = billboards.FirstOrDefault(c => c.Address == dataContextFromBtn.Address);
            string message = $"Admin deleted billboard {dataContextFromBtn.Address}";
            Log log = new Log(DateTime.Now, message);
            _createNewLogRepository.Create(log);
            _createNewBillboardRepository.Delete(billboard);
        }
    }
}
