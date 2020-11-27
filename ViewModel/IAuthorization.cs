using System;
using System.Collections.Generic;
using System.Text;

namespace BillboardsProject.ViewModel
{
    interface IAuthorization
    {
        string AuthorizationLogin { get; set; }
        string AuthorizationPassword { get; set; }
    }
}
