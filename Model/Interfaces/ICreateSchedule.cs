using System;
using System.Collections.Generic;
using System.Text;

namespace BillboardsProject.Model.Interfaces
{
    public interface ICreateSchedule
    {
        public string NameVideo { get; set; }
        public int CountOfRepeat { get; set; }

    }
}
