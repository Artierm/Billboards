namespace DAL.Models
{
    public class ScheduleAndVideo
    {
        public int Id { get; set; }

        public Video Video { get; set; }

        public string VideoName { get; set; }

        public Schedule Schedule { get; set; }


        public ScheduleAndVideo() { }

        public ScheduleAndVideo(Video video, Schedule schedule, string videoName)
        {
            Video = video;
            Schedule = schedule;
            VideoName = videoName;
        }


    }
}
