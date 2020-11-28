﻿namespace BillboardsProject
{
    class Billboard
    {
        public int Id { get; set; }

        public string Owner { get; set; }

        public string Address { get; set; }

        //public string NameVideo { get; set; }

        //public string View { get; set; }

        public Billboard() { }

        public Billboard(string owner, string address)
        {
            Owner = owner;
            Address = address;
        }

    }
}
