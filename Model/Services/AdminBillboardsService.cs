using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Windows.Controls;

namespace BillboardProject.Presents
{
    public class AdminBillboardsService
    {
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        public AdminBillboardsService(ICreateNewBillboardRepository createNewBillboardRepository)
        {
            _createNewBillboardRepository = createNewBillboardRepository;
        }

        public void ViewBillboard(object sender, out int id, out string address, out string owner)
        {

            Button btnSender = (Button)sender;
            var dataContextFromButton = (DAL.Models.Billboard)btnSender.DataContext;

            address = dataContextFromButton.Address;
            id = dataContextFromButton.Id;
            owner = dataContextFromButton.Owner;
        }
    }
}
