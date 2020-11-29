using System;
using System.Collections.Generic;
using System.Text;

namespace BillboardsProject.ViewModel
{
    interface ICreateUsers
    {
        public string UserLogin { get; set; }

        public string  UserPassword { get; set; }

        public string UserPasswordRepeat { get; set; }

    }
}
