using BusinessObject;
using DataAccess.Repository;
using VemsApi.Dto.ClassroomDto;
using VemsApi.Dto.PaginationDto;
using VemsApi.Dto.ScheduleDto;
using VemsApi.Dto.SlotDto;

namespace VemsApi.Services
{
    public interface IScheduleService
    {

        // Slot
        Task<IEnumerable<Slot>> GetAllSlot();
        Task<Slot> CreateSlot(CreateSlotDto request);
        Task<bool> UpdateSlot(UpdateSlotDto request);
        Task<bool> DeleteSlot(DeleteSlotDto request);

        // Schedule
        Task<List<ScheduleResponse>> GetAllScheduleOfClass(Guid request);
        Task<object> GetAllSchedule(PaginationRequest request);
        Task<Schedule> CreateSchedule(CreateScheduleDto request);
        Task<List<Schedule>> CreateListSchedule(List<CreateScheduleDto> request);
        Task<bool> UpdateSchedule(UpdateScheduleDto request);
        Task<bool> DeleteSchedule(DeleteSchedule request);


        //Schedule detail
        Task<bool> CreateScheduleDetail(CreateScheduleDetailRequest request);
        Task<ScheduleDetailResponseDto> GetScheduleDetail(Guid request);
        Task<object> GetAllTeacherScheduleDetail(PaginationRequest request);
        Task<TeacherScheduleResponse> GetTeacherScheduleDetail(Guid request);


    }

    public class ScheduleService : IScheduleService
    {
        private readonly ISlotRepository slotRepository;
        private readonly IScheduleRepository scheduleRepository;
        public ScheduleService()
        {
            slotRepository = new SlotRepository();
            scheduleRepository = new ScheduleRepository();
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

            if (slotDb == null) return false;
            slotDb.StartTime = request.StartTime;
            slotDb.EndTime = request.EndTime;
            slotDb.SlotIndex = request.SlotIndex;
            return await slotRepository.UpdateSlotTimeAsync(slotDb);

        }

        public async Task<List<ScheduleResponse>> GetAllScheduleOfClass(Guid request)
        {
            return await scheduleRepository.GetSchedulesByClassroomAsync(request);
        }

        public async Task<object> GetAllSchedule(PaginationRequest request)
        {
            int pageNumber = request.PageNumber;
            int pageSize = request.PageSize;

            // Get all schedules and count
            List<ScheduleResponse> schedules = await scheduleRepository.GetAllSchedulesAsync();
            List<ScheduleResponse> dataPaginated = schedules.Select(classroom => classroom).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            int totalRecord = schedules.Count();

            int totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);

            return new
            {
                totalPage,
                totalRecord,
                pageNumber,
                pageSize,
                pageData = dataPaginated
            };
        }

        public async Task<Schedule> CreateSchedule(CreateScheduleDto request)
        {
            Schedule newData = new Schedule();
            newData.ClassroomId = request.ClassroomId;
            newData.Time = DateTime.Parse(request.Time);
            newData.CreateAt = DateTime.Now;
            return await scheduleRepository.CreateScheduleAsync(newData);
        }

        public async Task<List<Schedule>> CreateListSchedule(List<CreateScheduleDto> request)
        {
            List<Schedule> createDatas = new List<Schedule>();
            foreach(var item in request)
            {
                Schedule newData = new Schedule();
                newData.ClassroomId = item.ClassroomId;
                newData.Time = DateTime.Parse(item.Time);
                newData.CreateAt = DateTime.Now;
                createDatas.Add(newData);
            }
            return await scheduleRepository.CreateListScheduleAsync(createDatas);


            throw new NotImplementedException();
        }

        public async Task<bool> UpdateSchedule(UpdateScheduleDto request)
        {
            Schedule newData = await scheduleRepository.GetScheduleByIdAsync(request.ScheduleId);
            newData.ClassroomId = request.ClassroomId;
            newData.Time = DateTime.Parse(request.Time);
            return await scheduleRepository.UpdateScheduleAsync(newData);
        }

        public async Task<bool> DeleteSchedule(DeleteSchedule request)
        {
            return await scheduleRepository.DeleteScheduleAsync(request.ScheduleId);
        }

        public async Task<bool> CreateScheduleDetail(CreateScheduleDetailRequest request)
        {
            return await scheduleRepository.CreateScheduleDetail(request);
        }

        public async Task<ScheduleDetailResponseDto> GetScheduleDetail(Guid request)
        {
            return await scheduleRepository.GetScheduleDetail(request); 
        }

        public async Task<object> GetAllTeacherScheduleDetail(PaginationRequest request)
        {

            int pageNumber = request.PageNumber;
            int pageSize = request.PageSize;

            IEnumerable<TeacherScheduleResponse> schedule = await scheduleRepository.GetAllTeacherScheduleDetail();
            IEnumerable<TeacherScheduleResponse> dataPaginated = schedule.Select(item=> item).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            int totalRecord = schedule.Count();

            int totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);

            return new
            {
                totalPage,
                totalRecord,
                pageNumber,
                pageSize,
                pageData = dataPaginated
            };

        }

        public async Task<TeacherScheduleResponse> GetTeacherScheduleDetail(Guid request)
        {
            return await scheduleRepository.GetTeacherScheduleDetail(request);
        }
    }
}
