using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillboardsProject.Presents
{
    class CreateNewBillboardPresenter
    {
        public CreateNewBillboardPage createNewBillboard;
        DatabaseContext database;
        public CreateNewBillboardPresenter(CreateNewBillboardPage createNewBillboard)
        {
            this.createNewBillboard = createNewBillboard;
            database = new DatabaseContext();
            this.createNewBillboard.AddBillboardEvent += CheckBillboard;
        }

        public void CheckBillboard(object sender, EventArgs e, string address)
        {
            Billboard billboard = new Billboard(string.Empty, address);
            database.Add(billboard);
            database.SaveChanges();
        }
    }
}
