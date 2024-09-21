using BusinessObject;
using DataAccess.Repository;
using VemsApi.Dto.SlotDto;

namespace VemsApi.Services
{
    public interface IScheduleService
    {
        Task<IEnumerable<Slot>> GetAllSlot();
        Task<Slot> CreateSlot(CreateSlotDto request);
        Task<bool> UpdateSlot(UpdateSlotDto request);
        Task<bool> DeleteSlot(DeleteSlotDto request);
    }

    public class ScheduleService : IScheduleService
    {
        private readonly ISlotRepository slotRepository;
        private readonly ISlotDetailRepository slotDetailRepository;
        public ScheduleService()
        {
           slotDetailRepository = new SlotDetailRepository();
           slotRepository = new SlotRepository();
        }

        public async Task<IEnumerable<Slot>> GetAllSlot()
        {
            return await slotRepository.GetAllSlotAsync();
        }

        public async Task<Slot> CreateSlot(CreateSlotDto request)
        {
            Slot newslot = new Slot();
            newslot.StartTime = request.StartTime;  
            newslot.EndTime = request.EndTime;
            newslot.SlotIndex = request.SlotIndex;
            return await slotRepository.CreateSlotAsync(newslot);
        }

        public async Task<bool> DeleteSlot(DeleteSlotDto request)
        {
            return await slotRepository.DeleteSlotAsync(request.Id);

        }

        public async Task<bool> UpdateSlot(UpdateSlotDto request)
        {
            var slotDb = await slotRepository.GetSlotByIdAsync(request.Id);

            if(slotDb == null) return false;
            slotDb.StartTime = request.StartTime;
            slotDb.EndTime = request.EndTime;
            slotDb.SlotIndex = request.SlotIndex;
            return await slotRepository.UpdateSlotTimeAsync(slotDb);

        }
    }
}
