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
        private static SlotDAO instance = null;

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

        public async Task<Slot> GetSlotByIdAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Slots.AsNoTracking().FirstOrDefaultAsync(slot => slot.Id == id).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tải dữ liệu tiết học!");
            }
        }

        public async Task<Slot> GetSlotBySlotIndexAsync(int slotIndex)
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
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
<<<<<<< HEAD
                        if (existingSlot.SlotIndex == slot.SlotIndex)
                        {
                            throw new InvalidOperationException($"Tiết học thứ {existingSlot.SlotIndex} đã tồn tại!");
                        }
=======
                        bool slotIndexExists = await context.Slots.AsNoTracking().AnyAsync(s => s.SlotIndex == slot.SlotIndex).ConfigureAwait(false);
                        bool startTimeExists = await context.Slots.AsNoTracking().AnyAsync(s => s.StartTime == slot.StartTime).ConfigureAwait(false);
                        bool endTimeExists = await context.Slots.AsNoTracking().AnyAsync(s => s.EndTime == slot.EndTime).ConfigureAwait(false);
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96

                        if (slotIndexExists)
                        {
<<<<<<< HEAD
                            throw new InvalidOperationException($"Tiết học bắt đầu lúc {existingSlot.StartTime} kết thúc lúc {existingSlot.EndTime} đã tồn tại!");
=======
                            throw new Exception("A slot with the same SlotIndex already exists.");
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96
                        }
                        if (startTimeExists)
                        {
                            throw new Exception("A slot with the same StartTime already exists.");
                        }
                        if (endTimeExists)
                        {
                            throw new Exception("A slot with the same EndTime already exists.");
                        }
                        context.Slots.Add(slot);
                        await context.SaveChangesAsync().ConfigureAwait(false);
                        await transaction.CommitAsync().ConfigureAwait(false);
                    }
<<<<<<< HEAD

                    var created = context.Slots.Add(slot).Entity;
                    await context.SaveChangesAsync().ConfigureAwait(false);
                    return created;
=======
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96
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

<<<<<<< HEAD

        public async Task<bool> UpdateSlotTimeAsync(Slot updatedSlot)
=======
        public async Task UpdateSlotTimeAsync(Slot updatedSlot)
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96
        {
            try
            {
                using (var context = new VemsContext())
                {
<<<<<<< HEAD
                    var existingSlot = await context.Slots.SingleOrDefaultAsync(s => s.Id == updatedSlot.Id).ConfigureAwait(false);

                    if (existingSlot != null)
=======
                    using (var transaction = await context.Database.BeginTransactionAsync().ConfigureAwait(false))
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96
                    {
                        var existingSlot = await context.Slots.AsNoTracking().FirstOrDefaultAsync(s => s.Id == updatedSlot.Id).ConfigureAwait(false);

                        if (existingSlot != null)
                        {
                            existingSlot.StartTime = updatedSlot.StartTime;
                            existingSlot.EndTime = updatedSlot.EndTime;
                            existingSlot.SlotIndex = updatedSlot.SlotIndex;

                            context.Slots.Update(existingSlot);
                            await context.SaveChangesAsync().ConfigureAwait(false);
                            await transaction.CommitAsync().ConfigureAwait(false);
                        }
                        else
                        {
                            throw new Exception("Slot not found.");
                        }
<<<<<<< HEAD
                    }
                    else
                    {
                        throw new InvalidOperationException("Không tìm thấy tiết học");
=======
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96
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
                    using (var transaction = await context.Database.BeginTransactionAsync().ConfigureAwait(false))
                    {
<<<<<<< HEAD
                        throw new InvalidOperationException("Không tìm thấy tiết học");
                    }
=======
                        var existingSlot = await context.Slots.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id).ConfigureAwait(false);
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96

                        if (existingSlot != null)
                        {
                            context.Slots.Remove(existingSlot);

                            await context.SaveChangesAsync().ConfigureAwait(false);
                            await transaction.CommitAsync().ConfigureAwait(false);
                        }
                        else
                        {
                            throw new Exception("Slot not found.");
                        }
                    }
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
