using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject.Presents
{
    class RegisterBillboardPresenter
    {
        public RegisterBillboardPage registerBillboard;
        DatabaseContext database;
        public RegisterBillboardPresenter(RegisterBillboardPage registerBillboard)
        {
            this.registerBillboard = registerBillboard;
            database = new DatabaseContext();
            this.registerBillboard.RegisterBillboardEvent += RegisterBillboard;
        }
      
        public void RegisterBillboard(object sender, EventArgs e)
        {
            //Просто в базу данных в Owner у билборда добавить логин.

            List<Billboard> billboards = database.Billboards.ToList();
            List<User> users = database.Users.ToList();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (Billboard)btnSender.DataContext;
            var billboard = billboards.Find(c => c.Id == dataContextFromBtn.Id);
            database.Billboards.Remove(billboard);
            var address = dataContextFromBtn.Address;
            var owner = users.Find(c => c.Id == AuthorizationPage.UserId);
            Billboard billboard1 = new Billboard(owner.Login, address);
            database.Add(billboard1);
            database.SaveChanges();

        }
    }
}
