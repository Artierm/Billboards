using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace BillboardProject.View
{
    public partial class CreateSchedulePage : Page
    {
        private readonly DatabaseContext database;
        public CreateSchedulePage()
        {
            InitializeComponent();
            database = new DatabaseContext();
      
            DynamicCheckBox();         
        }

        public void Button_Click_Save_and_Continue(object sender, RoutedEventArgs e)
        {
           var videos =  CheckVideos();
           CreateScheduleForUser(videos);
            this.NavigationService.Navigate(new SchedulePage(new CreateNewScheduleRepository(),new CreateNewBillboardRepository(), new CreateNewScheduleAndVideoRepository(), new CreateNewVideoRepository()));
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SchedulePage(new CreateNewScheduleRepository(), new CreateNewBillboardRepository(), new CreateNewScheduleAndVideoRepository(), new CreateNewVideoRepository()));
        }

        private void DynamicCheckBox()
        {
            var itemList = database.Videos.ToList();
               // _createNewVideoRepository.GetAll();
            var itemCorrectList = itemList.Where(c => c.OwnerId == AuthorizationPage.UserId);
            foreach (var item in itemCorrectList)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Name = "video_checkbox";
                checkBox.Content = item.NameOfVideo.ToString();
                scheduleCheckbox.Children.Add(checkBox);
            }
            Button button = new Button();
            button.Content = "Save and continue";
            button.Click += Button_Click_Save_and_Continue;
            button.Width = 150;
            scheduleCheckbox.Children.Add(button);
        }

        //занести в сервис
        private List<Video> CheckVideos()
        {
            List<Video> videos = database.Videos.ToList();
            List<Video> checkVideos = new List<Video>();

            List<CheckBox> checkBoxes = new List<CheckBox>();

            foreach (Object item in scheduleCheckbox.Children)
            {
                if (item is CheckBox box)
                {
                    checkBoxes.Add(box);
                }
            }

            foreach (CheckBox item in checkBoxes)
            {
                if ((bool) item.IsChecked)
                {
                    var value = videos.Find(c => c.NameOfVideo == item.Content.ToString());
                    checkVideos.Add(value);
                }
            }



            return checkVideos;
        }


        private void CreateScheduleForUser(List<Video> checkVideos)
        {
            var user = database.Users.FirstOrDefault(c => c.Id == AuthorizationPage.UserId);
            Schedule schedule = new Schedule(null, null, user);
            database.Schedules.Add(schedule);
            foreach (var video in checkVideos)
            {
                ScheduleAndVideo scheduleAndVideo = new ScheduleAndVideo(video,  schedule, video.NameOfVideo);
                database.ScheduleAndVideo.Add(scheduleAndVideo);
            }

            database.SaveChanges();
        }


    }
}
