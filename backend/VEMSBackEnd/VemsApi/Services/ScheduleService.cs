using DataAccess.Repository;

namespace VemsApi.Services
{
    public interface IScheduleService
    {
        public void CreateSchedule();
    }
    public class ScheduleService : IScheduleService
    {
        private readonly ISlotRepository _slotRepository;
        public ScheduleService()
        {
            _slotRepository = new SlotRepository();
        }
        public void CreateSchedule()
        {

        }
    }
}
