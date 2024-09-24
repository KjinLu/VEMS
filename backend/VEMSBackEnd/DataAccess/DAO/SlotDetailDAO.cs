using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class SlotDetailDAO
    {
        private static readonly object InstanceLock = new object();
        private static SlotDetailDAO instance = null;

        public static SlotDetailDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if(instance == null)
                    {
                        instance = new SlotDetailDAO(); 
                    }
                    return instance;
                }
            }
        }

        public async Task<SlotDetail> GetSlotDetailByIdAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.SlotDetails.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching slot by SlotIndex: {ex.Message}", ex);
            }
        }

        public async Task CreateSlotDetailAsync(SlotDetail slotDetail)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        bool slotDetailIdExists = await context.SlotDetails.AsNoTracking().AnyAsync(s => s.Id == slotDetail.Id).ConfigureAwait(false);
                      
                        if (slotDetailIdExists)
                        {
                            throw new Exception("A slotDetail with the same slotDetailId already exists.");
                        }
                        
                        context.SlotDetails.Add(slotDetail);
                        await context.SaveChangesAsync().ConfigureAwait(false);
                        await transaction.CommitAsync().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating slotDetail: {ex.Message}", ex);
            }
        }

        public async Task UpdateSlotDetailAsync(SlotDetail slotDetail)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    using (var transaction = await context.Database.BeginTransactionAsync().ConfigureAwait(false))
                    {
                        var existingSlotDetail = await context.SlotDetails.AsNoTracking().FirstOrDefaultAsync(s => s.Id == slotDetail.Id).ConfigureAwait(false);

                        if (existingSlotDetail != null)
                        {
                            existingSlotDetail.SubjectID = slotDetail.SubjectID;
                            existingSlotDetail.TeacherID = slotDetail.TeacherID;
                            existingSlotDetail.SessionID = slotDetail.SessionID;
                            existingSlotDetail.SlotID = slotDetail.SlotID;

                            context.SlotDetails.Update(existingSlotDetail);
                            await context.SaveChangesAsync().ConfigureAwait(false);
                            await transaction.CommitAsync().ConfigureAwait(false);
                        }
                        else
                        {
                            throw new Exception("slotDetail not found.");
                        }
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while updating the slotDetail. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating slotDetail time: {ex.Message}", ex);
            }
        }
        public async Task DeleteSlotDetailAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    using (var transaction = await context.Database.BeginTransactionAsync().ConfigureAwait(false))
                    {
                        var existingSlotdetail = await context.SlotDetails.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id).ConfigureAwait(false);

                        if (existingSlotdetail != null)
                        {
                            context.SlotDetails.Remove(existingSlotdetail);

                            await context.SaveChangesAsync().ConfigureAwait(false);
                            await transaction.CommitAsync().ConfigureAwait(false);
                        }
                        else
                        {
                            throw new Exception("SlotDetail not found.");
                        }
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while deleting the SlotDetail. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting SlotDetail: {ex.Message}", ex);
            }
        }
    }
}
