using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace BillboardsProject.Presents
{
    class CrudUserPresent
    {

        public CrudUser crudUser;
        ApplicationContext database;

        public CrudUserPresent(CrudUser crudUser)
        {
            this.crudUser = crudUser;
            database = new ApplicationContext();
            this.crudUser.DeleteUserEvent += RemoveUser;
        }
        

        public void RemoveUser(object sender, EventArgs e)
        {
            List<Billboard> billboards = database.Billboards.ToList();       
            List<User> users = database.Users.ToList();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (User)btnSender.DataContext;
            var user = users.Find(c => c.Id == dataContextFromBtn.Id);
            var removeBillboards = billboards.Where(c => c.Owner == dataContextFromBtn.Login);

            foreach(var billboard in removeBillboards)
            {
                Billboard billboard1 = new Billboard(string.Empty, billboard.Address);
                database.Billboards.Add(billboard1);
                database.Remove(billboard);
              
            }
            database.Remove(user);
            database.SaveChanges();
        }

        public void CreateUser(object sender, EventArgs e)
        {         
            List<User> users = database.Users.ToList();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (User)btnSender.DataContext;
            var user = users.Find(c => c.Id == dataContextFromBtn.Id);
            database.Remove(user);
            database.SaveChanges();
        }
    }
}
