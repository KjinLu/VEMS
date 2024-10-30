export type AttendanceReport = {
  attendanceStatusID: string;
  dateAttendance: string;
  dayOfWeek: number;
  periodName: string;
  studentCharge: string;
  teacherCharge: string;
  statusName: string;
  reasonName: string;
  description: string;
};

export type AttendanceReportWithIndex = AttendanceReport & { index: number };
