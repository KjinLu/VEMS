using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ISlotRepository
    {
        Task<List<Slot>> GetAllSlotAsync();
        Task<List<int>> GetListSlotIndexAsync();
        Task<Slot?> GetSlotByIdAsync(Guid id);
        Task<Slot?> GetSlotBySlotIndexAsync(int slotIndex);
        Task<TimeSpan?> GetStartTimeByIdAsync(Guid id);
        Task<TimeSpan?> GetEndTimeByIdAsync(Guid id);
        Task<Slot> CreateSlotAsync(Slot slot);
        Task<bool> UpdateSlotTimeAsync(Slot updatedSlot);
        Task<bool> DeleteSlotAsync(Guid id);
    }

    public class SlotRepository : ISlotRepository
    {
        public async Task<Slot> CreateSlotAsync(Slot slot)
        {
           return await SlotDAO.Instance.CreateSlotAsync(slot).ConfigureAwait(false);
        }

        public async Task<List<Slot>> GetAllSlotAsync()
        {
            return await SlotDAO.Instance.GetAllSlotAsync();
        }

        public async Task<List<int>> GetListSlotIndexAsync()
        {
            return await SlotDAO.Instance.GetListSlotIndexAsync();
        }

        public async Task<Slot?> GetSlotByIdAsync(Guid id)
        {
            return await SlotDAO.Instance.GetSlotByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<Slot?> GetSlotBySlotIndexAsync(int slotIndex)
        {
            return await SlotDAO.Instance.GetSlotBySlotIndexAsync(slotIndex).ConfigureAwait(false);
        }

        public async Task<TimeSpan?> GetStartTimeByIdAsync(Guid id)
        {
            return await SlotDAO.Instance.GetStartTimeByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<TimeSpan?> GetEndTimeByIdAsync(Guid id)
        {
            return await SlotDAO.Instance.GetEndTimeByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<bool> UpdateSlotTimeAsync(Slot updatedSlot)
        {
           return await SlotDAO.Instance.UpdateSlotTimeAsync(updatedSlot).ConfigureAwait(false);
        }

        public async Task<bool> DeleteSlotAsync(Guid id)
        {
          return  await SlotDAO.Instance.DeleteSlotAsync(id).ConfigureAwait(false);
        }
    }
}
