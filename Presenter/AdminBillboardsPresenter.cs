using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace BillboardsProject.Presents
{
    class AdminBillboardsPresenter
    {
        public AdminBillboardsPage adminBillboards;
        DatabaseContext database;

        public AdminBillboardsPresenter(AdminBillboardsPage adminBillboards)
        {
            this.adminBillboards = adminBillboards;
            database = new DatabaseContext();
            this.adminBillboards.ViewBillboardEvent += ViewBillboard;
        }

        public void ViewBillboard(object sender, EventArgs e, out int id, out string address, out string owner)
        {
            //Просто в базу данных в Owner у билборда добавить логин.

            Button btnSender = (Button)sender;
            var dataContextFromButton = (Billboard)btnSender.DataContext;

            address = dataContextFromButton.Address;
            id = dataContextFromButton.Id;
            owner = dataContextFromButton.Owner;
        }
    }
}
