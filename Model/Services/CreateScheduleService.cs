using System;
using System.Collections.Generic;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Windows.Controls;
using BillboardsProject.View;
using DAL.Context;

namespace BillboardProject
{
    public class CreateScheduleService
    {
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        public CreateScheduleService(ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleRepository createNewScheduleRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewVideoRepository createNewVideoRepository)
        {
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewScheduleRepository = createNewScheduleRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewVideoRepository = createNewVideoRepository;
        }

        public void AddBillboardToSchedule(object sender, out Billboard billboard)
        {
            Button btnSender = (Button)sender;
            var dataContextFromButton = (Billboard)btnSender.DataContext;
            int id = dataContextFromButton.Id; 
            billboard = _createNewBillboardRepository.GetById(id);
        }

        public void ChooseSchedule(object sender)
        {
            Button btnSender = (Button)sender;
            var dataContextFromButton = (Schedule)btnSender.DataContext;
            var schedule = _createNewScheduleRepository.GetById(dataContextFromButton.Id);
            schedule.Billboard = BillboardAddSchedulePage.Billboard;
            schedule.BillboardAddress = BillboardAddSchedulePage.Billboard.Address;
            _createNewScheduleRepository.Update(schedule);

        }

        public List <Video> ViewSchedule(object sender)
        {
            List<Video> videos = new List<Video>();
            Button btnSender = (Button)sender;
            var dataContextFromButton = (Schedule)btnSender.DataContext;
            var schedule = _createNewScheduleRepository.GetById(dataContextFromButton.Id);
            var userSchedulesAndVideos = _createNewScheduleAndVideoRepository.GetByScheduleAll(schedule);
            foreach (var item in userSchedulesAndVideos)
            {
                var video = item.Video;
                videos.Add(video);
            }
            return videos;
        }

        public void DeleteSchedule(object sender)
        {
            Button btnSender = (Button)sender;
            var dataContextFromButton = (Schedule)btnSender.DataContext;
            var schedule = _createNewScheduleRepository.GetById(dataContextFromButton.Id);
            _createNewScheduleRepository.Delete(schedule);
            var deleteScheduleAndVideos = _createNewScheduleAndVideoRepository.GetByScheduleAll(schedule);
            foreach (var itemScheduleAndVideo in deleteScheduleAndVideos)
            {
                _createNewScheduleAndVideoRepository.Delete(itemScheduleAndVideo);
            }
        }
    }
}
