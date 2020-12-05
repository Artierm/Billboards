namespace BillboardProject.Model
{
    interface ICreateUsers
    {
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserPasswordRepeat { get; set; }
    }
}
