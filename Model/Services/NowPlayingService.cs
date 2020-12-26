using System;
using System.Windows.Controls;
using BillboardsProject.View;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace BillboardsProject.Model.Services
{

    public class NowPlayingService
    {
        public static string NowPlay { get; set; }

        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly  ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;

        public NowPlayingService(ICreateNewVideoRepository createNewVideoRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleRepository createNewScheduleRepository)
        {
            _createNewVideoRepository = createNewVideoRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewScheduleRepository = createNewScheduleRepository;
        }

        public void ContextBillboard(object sender, out Billboard billboard)
        {
            Button btnSender = (Button)sender;
            var dataContextFromButton = (Billboard)btnSender.DataContext;
            billboard = _createNewBillboardRepository.GetById(dataContextFromButton.Id);
        }


        public string NowPlayVideoTime()
        {
            string nowPlayVideoName = string.Empty;
            string  address = NowPlaying.Billboard.Address;
            var schedule = _createNewScheduleRepository.GetByBillboardAddress(address);
            var schedulesAndVideo = _createNewScheduleAndVideoRepository.GetByScheduleAll(schedule);
            int timeOfVideo = (int)Math.Floor(60.0 / schedulesAndVideo.Count);
            for (int i = 0; i < schedulesAndVideo.Count; i++)
            {
                if (i * timeOfVideo < DateTime.Now.Minute)
                {
                    nowPlayVideoName = schedulesAndVideo[i].VideoName;
                }
            }

            return nowPlayVideoName;
        }
    }
}
