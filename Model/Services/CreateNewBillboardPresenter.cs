using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillboardsProject.Presents
{
    class CreateNewBillboardPresenter
    {
        private DatabaseContext _database;
        public CreateNewBillboardPresenter()
        {
            _database = new DatabaseContext();
        }

        public void AddBillboard(string address)
        {
            Billboard billboard = new Billboard(string.Empty, address);
            _database.Add(billboard);
            _database.SaveChanges();
        }
    }
}
