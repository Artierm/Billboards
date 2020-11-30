using System;
using System.Collections.Generic;
using System.Text;

namespace BillboardsProject.ViewModel
{
    public interface ICreateBillboard
    {
       string RegistrationLogin { get; set; }
       string RegistrationPassword { get; set; }
       string RegistrationPasswordRepeat { get; set; }
    }
}
