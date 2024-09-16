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
        private static SlotDetailDAO? instance = null;

        public static SlotDetailDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SlotDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<IEnumerable<SlotDetail>> GetAllSlotDetailAsync()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.SlotDetails.AsNoTracking().ToListAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching all slot detail: {ex.Message}", ex);
            }
        }

        public async Task<SlotDetail?> GetSlotDetailByIdAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.SlotDetails.FindAsync(id).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching slot by id: {ex.Message}", ex);
            }
        }

        public async Task CreateSlotDetailAsync(SlotDetail slotDetail)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    bool exists = await context.SlotDetails.AnyAsync(s =>  s.SubjectID == slotDetail.SubjectID &&
                                        s.TeacherID == slotDetail.TeacherID &&
                                        s.SessionID == slotDetail.SessionID &&
                                        s.SlotID == slotDetail.SlotID)
                                        .ConfigureAwait(false);

                    if (exists)
                    {
                        throw new InvalidOperationException("A SlotDetail with the same values already exists.");
                    }

                    context.SlotDetails.Add(slotDetail);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating SlotDetail: {ex.Message}", ex);
            }
        }


        public async Task UpdateSlotDetailAsync(SlotDetail slotDetail)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var existingSlotDetail = await context.SlotDetails.FindAsync(slotDetail.Id).ConfigureAwait(false);

                    if (existingSlotDetail != null)
                    {
                        if (existingSlotDetail.SubjectID != slotDetail.SubjectID ||
                        existingSlotDetail.TeacherID != slotDetail.TeacherID ||
                        existingSlotDetail.SessionID != slotDetail.SessionID ||
                        existingSlotDetail.SlotID != slotDetail.SlotID)
                        {
                            existingSlotDetail.SubjectID = slotDetail.SubjectID;
                            existingSlotDetail.TeacherID = slotDetail.TeacherID;
                            existingSlotDetail.SessionID = slotDetail.SessionID;
                            existingSlotDetail.SlotID = slotDetail.SlotID;

                            await context.SaveChangesAsync().ConfigureAwait(false);
                        }
                        else
                        {
                            throw new InvalidOperationException("Slot detail not found.");
                        }
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while updating the slot detail. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating slot detail time: {ex.Message}", ex);
            }
        }

        public async Task DeleteSlotDetailAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var existingSlotdetail = await context.SlotDetails.FindAsync(id).ConfigureAwait(false);

                    if (existingSlotdetail != null)
                    {
                        context.SlotDetails.Remove(existingSlotdetail);
                        await context.SaveChangesAsync().ConfigureAwait(false);
                    }
                    else
                    {
                        throw new InvalidOperationException("SlotDetail not found.");
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while deleting the slot detail. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting slot detail: {ex.Message}", ex);
            }
        }
    }
}
