using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace BillboardsProject.Presents
{
    class UserBillboardsPresenter
    {

        public UserBillboardsPage userBillboards;
        DatabaseContext database;
        public UserBillboardsPresenter(UserBillboardsPage userBillboards)
        {
            this.userBillboards = userBillboards;
            database = new DatabaseContext();
            this.userBillboards.ViewBillboardEvent += ViewBillboard;
        }

        public void ViewBillboard(object sender, EventArgs e, out int id, out string address, out string owner)
        {
            Button btnSender = (Button)sender;
            var dataContextFromButton = (Billboard)btnSender.DataContext;
            
            address = dataContextFromButton.Address;
            id = dataContextFromButton.Id;
            owner = dataContextFromButton.Owner;
        }

    }
}
