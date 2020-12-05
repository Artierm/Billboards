using Billbort.Model.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Billbort.View
{
    /// <summary>
    /// Interaction logic for AmountOfRepeatVideos.xaml
    /// </summary>
    public partial class AmountOfRepeatVideos : Page
    {
       private List<Video> Videos { get; set; }
        public AmountOfRepeatVideos(List<Video> videos)
        {
            InitializeComponent();
            Videos = videos;
            videosGrid.ItemsSource = videos;
            //Initialization();
        }


        //public void Initialization()
        //{
        //    foreach (var item in Videos)
        //    {
        //        TextBlock textBlock = new TextBlock();
        //        textBlock.Name = "video_name";
        //        textBlock.Text = item.NameOfVideo;
        //        TextBox textBox = new TextBox();
        //        textBox.Name = "video_count_of_repeat";
        //        videoCheckbox.Children.Add(textBlock);
        //        videoCheckbox.Children.Add(textBox);
        //    }
        //}
        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            
            this.NavigationService.Navigate(new CreateSchedulePage());
        }

        public void Button_Click_Save_and_Continue(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SchedulePage());
        }
    }
}
