using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Linq;
using System.Windows.Controls;

namespace BillboardProject.Presenter
{
    public class AdminViewBillboardService
    {
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        public AdminViewBillboardService(ICreateNewBillboardRepository createNewBillboardRepository)
        {
            _createNewBillboardRepository = createNewBillboardRepository;
        }

        public void DeleteBillboard(object sender)
        {
            var billboards = _createNewBillboardRepository.GetAll();
          
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (DAL.Models.Billboard)btnSender.DataContext;
            DAL.Models.Billboard billboard = billboards.FirstOrDefault(c => c.Address == dataContextFromBtn.Address);

            _createNewBillboardRepository.Delete(billboard);
        }
    }
}
