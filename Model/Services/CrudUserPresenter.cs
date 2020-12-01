using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace BillboardsProject.Presents
{
    class CrudUserPresenter
    {
        private DatabaseContext _database;

        public CrudUserPresenter()
        {
            _database = new DatabaseContext();
        }

        public void RemoveUser(object sender)
        {
            List<Billboard> billboards = _database.Billboards.ToList();       
            List<User> users = _database.Users.ToList();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (User)btnSender.DataContext;
            var user = users.Find(c => c.Id == dataContextFromBtn.Id);
            var removeBillboards = billboards.Where(c => c.Owner == dataContextFromBtn.Login);
        
            foreach(var billboard in removeBillboards)
            {
                billboard.Owner = string.Empty;
            }
            _database.Remove(user);
            _database.SaveChanges();
        }

        public void CreateUser(object sender, EventArgs e)
        {         
            List<User> users = _database.Users.ToList();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (User)btnSender.DataContext;
            var user = users.Find(c => c.Id == dataContextFromBtn.Id);
            _database.Remove(user);
            _database.SaveChanges();
        }
    }
}
