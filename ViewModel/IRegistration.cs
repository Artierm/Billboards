using System;
using System.Collections.Generic;
using System.Text;

namespace BillboardsProject.ViewModel
{
    public interface IRegistration
    {
       string RegistrationLogin { get; set; }
       string RegistrationPassword { get; set; }
       string RegistrationPasswordRepeat { get; set; }

    }
}
