namespace BillboardsProject
{
    class Video
    {
        public int Id { get; set; }
        public string NameVideo { get; set; }

        public int IdOwner { get; set; }
        public int TimeVideo { get; set; }

        public Video() { }

        public Video(string nameVideo, int timeVideo, int idOwner)
        {
            NameVideo = nameVideo;
            TimeVideo = timeVideo;
            IdOwner = idOwner;
        }
    }
}
