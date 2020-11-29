using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject.Presents
{
    class RegisterBillboardPresent
    {
        public RegisterBillboard registerBillboard;
        ApplicationContext database;
        public RegisterBillboardPresent(RegisterBillboard registerBillboard)
        {
            this.registerBillboard = registerBillboard;
            database = new ApplicationContext();
            this.registerBillboard.RegisterBillboardEvent += RegisterBillboard;
        }
      
        public void RegisterBillboard(object sender, EventArgs e)
        {
            List<Billboard> billboards = database.Billboards.ToList();
            List<User> users = database.Users.ToList();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (Billboard)btnSender.DataContext;
            var billboard = billboards.Find(c => c.Id == dataContextFromBtn.Id);
            database.Billboards.Remove(billboard);
            var address = dataContextFromBtn.Address;
            var owner = users.Find(c => c.Id == Authorization.IdUser);
            Billboard billboard1 = new Billboard(owner.Login, address);
            database.Add(billboard1);
            database.SaveChanges();

        }
    }
}
