using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace BillboardsProject.Presents
{
    class AdminBillboardsPresent
    {
        public AdminBillboards adminBillboards;
        ApplicationContext database;

        public AdminBillboardsPresent(AdminBillboards adminBillboards)
        {
            this.adminBillboards = adminBillboards;
            database = new ApplicationContext();
            this.adminBillboards.ViewBillboardEvent += ViewBillboard;
        }

        public void ViewBillboard(object sender, EventArgs e, out int id, out string address, out string owner)
        {
            //Просто в базу данных в Owner у билборда добавить логин.

            //List<Billboard> billboards = database.Billboards.ToList();
            //List<User> users = database.Users.ToList();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (Billboard)btnSender.DataContext;

            //var billboard = billboards.Find(c => c.Id == dataContextFromBtn.Id);
            //database.Billboards.Remove(billboard);
            address = dataContextFromBtn.Address;
            id = dataContextFromBtn.Id;
            owner = dataContextFromBtn.Owner;
            //var owner = users.Find(c => c.Id == Authorization.IdUser);
            //Billboard billboard1 = new Billboard(owner.Login, address);
            //database.Add(billboard1);
            ///database.SaveChanges();

        }
    }
}
