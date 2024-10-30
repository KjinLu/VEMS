export type AttendanceSchedule = {
  scheduleDetailID: string; // Unique identifier for the schedule
  attendanceTime: string; // ISO string representing the date and time of attendance
  className: string; // Name of the class (e.g., "10A4")
  classroomID: string; // Unique identifier for the classroom
  dayOfWeek: number; // Day of the week (1-7, where 1 is Monday)
  isAttendance: boolean; // Indicates if attendance was marked (true/false)
  periodName: string; // Name of the period (e.g., "Sáng")
  periodID: string;
};

export type AttendanceScheduleWithIndex = AttendanceSchedule & { index: number };
