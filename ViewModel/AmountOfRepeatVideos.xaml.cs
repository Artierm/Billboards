using DAL.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BillboardProject.Model.Services;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace BillboardProject.View
{
    public partial class AmountOfRepeatVideos : Page
    {
       private List<Video> Videos { get; set; }

      // private readonly CountVideosRepeatService _countVideosRepeatService;
        public AmountOfRepeatVideos(List<Video> videos)
        {
            InitializeComponent();
            Videos = videos;
            videosGrid.ItemsSource = videos;
            var createNewLogRepository =  new CreateNewLogRepository();
            var createNewUserRepository = new CreateNewUserRepository();
            var createNewVideoRepository = new CreateNewVideoRepository();
           // var createNewCountVideosRepeatRepository = new CreateNewCountVideosRepeatRepository();
                //  _countVideosRepeatService = new CountVideosRepeatService(createNewUserRepository, createNewLogRepository, createNewCountVideosRepeatRepository, createNewVideoRepository);
        }
        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            
            this.NavigationService.Navigate(new CreateSchedulePage()) ;
        }

        public void Button_Click_Save(object sender, RoutedEventArgs e)
        {
          //  _countVideosRepeatService.SaveCountOfRepeats(sender);
        }
    }
}
