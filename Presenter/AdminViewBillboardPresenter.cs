using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace BillboardsProject.Presenter
{
    class AdminViewBillboardPresenter
    {
        public AdminViewBillboardPage adminViewBillboardPage;
        DatabaseContext database;
        public AdminViewBillboardPresenter (AdminViewBillboardPage adminViewBillboardPage)
        {
            this.adminViewBillboardPage = adminViewBillboardPage;
            database = new DatabaseContext();
            this.adminViewBillboardPage.DeleteBillboardEvent += DeleteBillboard;
        }

        public void DeleteBillboard(object sender, EventArgs e)
        {       
            List<Billboard> billboards = database.Billboards.ToList();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (Billboard)btnSender.DataContext;
            var billboard = billboards.Find(c => c.Address == dataContextFromBtn.Address);
            database.Billboards.Remove(billboard);
            database.SaveChanges();
        }
    }
}
