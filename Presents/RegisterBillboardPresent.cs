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

        public void RegisterBillboard(object sender, RoutedEventArgs e)
        {
            List<Billboard> users = database.Billboards.ToList();
            var billboards = users.Where(c => c.Address == string.Empty);
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;           
                var billboardCheck = billboards.ToList().Find(c => c.Id == Convert.ToInt32(dataRowView[1].ToString()));
                var owner = database.Users.ToList().Find(c => c.Id == Authorization.IdUser);
                billboardCheck.Owner = owner.Login;
                database.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
