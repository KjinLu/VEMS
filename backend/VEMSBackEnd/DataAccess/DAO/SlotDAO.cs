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
                    return await context.Slots.AsNoTracking().ToListAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching all slots: {ex.Message}", ex);
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
                throw new Exception($"Error fetching slot indices: {ex.Message}", ex);
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
                throw new Exception($"Error fetching slot by Id: {ex.Message}", ex);
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
                throw new Exception($"Error fetching slot by SlotIndex: {ex.Message}", ex);
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
                throw new Exception($"Error fetching StartTime: {ex.Message}", ex);
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
                throw new Exception($"Error fetching EndTime: {ex.Message}", ex);
            }
        }

        public async Task CreateSlotAsync(Slot slot)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        bool slotIndexExists = await context.Slots.AsNoTracking().AnyAsync(s => s.SlotIndex == slot.SlotIndex).ConfigureAwait(false);
                        bool startTimeExists = await context.Slots.AsNoTracking().AnyAsync(s => s.StartTime == slot.StartTime).ConfigureAwait(false);
                        bool endTimeExists = await context.Slots.AsNoTracking().AnyAsync(s => s.EndTime == slot.EndTime).ConfigureAwait(false);

                        if (slotIndexExists)
                        {
                            throw new Exception("A slot with the same SlotIndex already exists.");
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
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while creating the slot. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating Slot: {ex.Message}", ex);
            }
        }

        public async Task UpdateSlotTimeAsync(Slot updatedSlot)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    using (var transaction = await context.Database.BeginTransactionAsync().ConfigureAwait(false))
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
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while updating the slot. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating Slot time: {ex.Message}", ex);
            }
        }

        public async Task DeleteSlotAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    using (var transaction = await context.Database.BeginTransactionAsync().ConfigureAwait(false))
                    {
                        var existingSlot = await context.Slots.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id).ConfigureAwait(false);

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
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while deleting the slot. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting Slot: {ex.Message}", ex);
            }
        }
    }
}
