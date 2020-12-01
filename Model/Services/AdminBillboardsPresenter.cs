using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace BillboardsProject.Presents
{
    class AdminBillboardsPresenter
    {
        private DatabaseContext _database;

        public AdminBillboardsPresenter()
        {
            _database = new DatabaseContext();
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
