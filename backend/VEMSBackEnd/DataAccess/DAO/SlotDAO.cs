using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class SlotDAO
    {
        private static readonly object InstanceLock = new object();
        private static SlotDAO? instance = null;

        public static SlotDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SlotDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<List<Slot>> GetAllSlotAsync()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Slots.AsNoTracking().OrderBy(slot => slot.SlotIndex).ToListAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tải dữ liệu tiết học!");
            }
        }

        public async Task<List<int>> GetListSlotIndexAsync()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Slots.AsNoTracking().Select(slot => slot.SlotIndex).ToListAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tải dữ liệu tiết học!");
            }
        }

        public async Task<Slot?> GetSlotByIdAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Slots.FindAsync(id).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tải dữ liệu tiết học!");
            }
        }

        public async Task<Slot?> GetSlotBySlotIndexAsync(int slotIndex)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Slots.AsNoTracking().FirstOrDefaultAsync(slot => slot.SlotIndex == slotIndex).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tải dữ liệu tiết học!");
            }
        }

        public async Task<TimeSpan?> GetStartTimeByIdAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Slots.AsNoTracking()
                                              .Where(slot => slot.Id == id)
                                              .Select(slot => slot.StartTime)
                                              .FirstOrDefaultAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tải dữ liệu tiết học!");
            }
        }

        public async Task<TimeSpan?> GetEndTimeByIdAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Slots.AsNoTracking()
                                              .Where(slot => slot.Id == id)
                                              .Select(slot => slot.EndTime)
                                              .FirstOrDefaultAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tải dữ liệu tiết học!");
            }
        }

        public async Task<Slot> CreateSlotAsync(Slot slot)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var existingSlot = await context.Slots
                        .AsNoTracking()
                        .FirstOrDefaultAsync(s => s.SlotIndex == slot.SlotIndex ||
                                                  (s.StartTime == slot.StartTime && s.EndTime == slot.EndTime))
                        .ConfigureAwait(false);

                    if (existingSlot != null)
                    {
                        if (existingSlot.SlotIndex == slot.SlotIndex)
                        {
                            throw new InvalidOperationException($"Tiết học thứ {existingSlot.SlotIndex} đã tồn tại!");
                        }

                        if (existingSlot.StartTime == slot.StartTime && existingSlot.EndTime == slot.EndTime)
                        {
                            throw new InvalidOperationException($"Tiết học bắt đầu lúc {existingSlot.StartTime} kết thúc lúc {existingSlot.EndTime} đã tồn tại!");
                        }
                    }

                    var created = context.Slots.Add(slot).Entity;
                    await context.SaveChangesAsync().ConfigureAwait(false);
                    return created;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Có lỗi xảy ra khi tạo tiết học, thử lại sau!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> UpdateSlotTimeAsync(Slot updatedSlot)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var existingSlot = await context.Slots.SingleOrDefaultAsync(s => s.Id == updatedSlot.Id).ConfigureAwait(false);

                    if (existingSlot != null)
                    {
                        if (existingSlot.StartTime != updatedSlot.StartTime ||
                        existingSlot.EndTime != updatedSlot.EndTime ||
                        existingSlot.SlotIndex != updatedSlot.SlotIndex)
                        {
                            existingSlot.StartTime = updatedSlot.StartTime;
                            existingSlot.EndTime = updatedSlot.EndTime;
                            existingSlot.SlotIndex = updatedSlot.SlotIndex;

                            await context.SaveChangesAsync().ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Không tìm thấy tiết học");
                    }
                    return true;

                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Có lỗi xảy ra khi cập nhật tiết học, thử lại sau!" );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteSlotAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var existingSlot = await context.Slots.FindAsync(id).ConfigureAwait(false);

                    if (existingSlot == null)
                    {
                        throw new InvalidOperationException("Không tìm thấy tiết học");
                    }

                    context.Slots.Remove(existingSlot);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Có lỗi xảy ra khi xóa tiết học, thử lại sau!");
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi xóa tiết học!");
            }
        }

    }
}
