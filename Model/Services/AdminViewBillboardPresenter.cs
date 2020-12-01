using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace BillboardsProject.Presenter
{
    class AdminViewBillboardPresenter
    {
        private DatabaseContext _database;
        public AdminViewBillboardPresenter ()
        {
            _database = new DatabaseContext();
        }

        public void DeleteBillboard(object sender)
        {
            List<Billboard> billboards = _database.Billboards.ToList();
            Button btnSender = (Button)sender;
            var dataContextFromBtn = (Billboard)btnSender.DataContext;
            var billboard = billboards.Find(c => c.Address == dataContextFromBtn.Address);
            _database.Billboards.Remove(billboard);
            _database.SaveChanges();
        }
    }
}
