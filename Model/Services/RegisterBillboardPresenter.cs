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
        private DatabaseContext _database;
        public RegisterBillboardPresenter()
        {
            _database = new DatabaseContext();
        }
      
        public void RegisterBillboard(object sender)
        {
            List<Billboard> billboards = _database.Billboards.ToList();
            List<User> users = _database.Users.ToList();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (Billboard)btnSender.DataContext;
            var billboard = billboards.Find(c => c.Id == dataContextFromBtn.Id);
            var owner = users.Find(c => c.Id == AuthorizationPage.UserId);
            billboard.Owner = owner.Login;
            _database.SaveChanges();

        }
    }
}
