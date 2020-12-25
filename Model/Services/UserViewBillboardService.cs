using DAL.Models;
using System.Windows.Controls;

namespace BillboardProject.Service
{
    public class UserViewBillboardService
    {
        public UserViewBillboardService()
        {
        }
        public void ViewBillboard(object sender, out int id, out string address, out string owner)
        {
            Button btnSender = (Button)sender;
            var dataContextFromButton = (Billboard)btnSender.DataContext;   
            address = dataContextFromButton.Address;
            id = dataContextFromButton.Id;
            owner = dataContextFromButton.Owner;
        }
    }
}
