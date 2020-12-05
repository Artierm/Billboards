using System;
using System.Collections.Generic;
using System.Text;

namespace Billbort.ViewModel
{
    public interface IAuthorization
    {
        string AuthorizationLogin { get; set; }
        string AuthorizationPassword { get; set; }
    }
}
