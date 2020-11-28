using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillboardsProject.Presents
{
    class CreateNewBillboardPresent
    {
        public CreateNewBillboard createNewBillboard;
        ApplicationContext database;
        public CreateNewBillboardPresent(CreateNewBillboard createNewBillboard)
        {
            this.createNewBillboard = createNewBillboard;
            database = new ApplicationContext();
            this.createNewBillboard.addBillboardEvent += CheckBillboard;
        }

        public void CheckBillboard(object sender, EventArgs e, string address)
        {
            Billboard billboard = new Billboard(string.Empty, address);
            database.Add(billboard);
            database.SaveChanges();
        }
    }
}
