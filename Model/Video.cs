namespace BillboardsProject
{
    class Video
    {
        public int Id { get; set; }
        public string NameOfVideo { get; set; }

        public int OwnerId { get; set; }
        public int TimeOfVideo { get; set; }

        public Video() { }

        public Video(string nameOfVideo, int timeOfVideo, int ownerId)
        {
            NameOfVideo = nameOfVideo;
            TimeOfVideo = timeOfVideo;
            OwnerId = ownerId;
        }
    }
}
