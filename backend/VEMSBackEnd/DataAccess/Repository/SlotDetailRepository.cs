using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ISlotDetailRepository
    {
        Task<SlotDetail?> GetSlotDetailByIdAsync(Guid id);
        Task<IEnumerable<SlotDetail>> GetAllSlotDetailAsync();
        Task CreateSlotDetailAsync(SlotDetail slotDetail);
        Task UpdateSlotDetailAsync(SlotDetail slotDetail);
        Task DeleteSlotDetailAsync(Guid id);
    }

    public class SlotDetailRepository : ISlotDetailRepository
    {
        public async Task<SlotDetail?> GetSlotDetailByIdAsync(Guid id)
        {
            return await SlotDetailDAO.Instance.GetSlotDetailByIdAsync(id).ConfigureAwait(false);
        }

        public async Task CreateSlotDetailAsync(SlotDetail slotDetail)
        {
            await SlotDetailDAO.Instance.CreateSlotDetailAsync(slotDetail).ConfigureAwait(false);
        }

        public async Task UpdateSlotDetailAsync(SlotDetail slotDetail)
        {
            await SlotDetailDAO.Instance.UpdateSlotDetailAsync(slotDetail).ConfigureAwait(false);
        }

        public async Task DeleteSlotDetailAsync(Guid id)
        {
            await SlotDetailDAO.Instance.DeleteSlotDetailAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<SlotDetail>> GetAllSlotDetailAsync()
        {
           return await SlotDetailDAO.Instance.GetAllSlotDetailAsync().ConfigureAwait(false);
        }
    }
}
